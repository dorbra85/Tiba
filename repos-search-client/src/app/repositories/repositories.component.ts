import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, FormBuilder, Validators} from '@angular/forms';
import { RepositoryService } from '@app/_services/repository.service';
import { AlertService } from '@app/_services';
import { first } from 'rxjs/operators';
import { Repository } from '@app/_models/repository';

@Component({
  selector: 'app-repositories',
  templateUrl: './repositories.component.html',
  styleUrls: ['./repositories.component.less']
})
export class RepositoriesComponent implements OnInit {
  form: FormGroup;
  submitted = false;
  loading = false;
  returnUrl: string;
  selectedRepos = new FormControl();
  reposNamesList: string[];
  reposList: Repository[];
  favoriteRepos : Repository[] = [];
  selected:number[];

  constructor( private formBuilder: FormBuilder,private alertService: AlertService,
    private repositoryService: RepositoryService
    ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      searchterm: ['', Validators.required],
  });
  }

  get f() { return this.form.controls; }
  getValues() {
    console.log(this.selected);
  }
  onSubmit() {
    this.submitted = true;

    if (this.form.invalid) {
        return;
    }

    this.loading = true;

    this.repositoryService.searchTerm(this.f.searchterm.value)
    .pipe(first())
    .subscribe(
        data => {
          console.log(data)
          let searchResults = Object.freeze(data)
          this.reposList = searchResults.map(result => ({
            id : result.id,
            name: result.name,
            fullName: result.fullName,
            description: result.description,
            private: result.private,
          }));
          this.loading = false
        },
        error => {
          console.log(error)
        });

    }

    saveFavorites(){
      if(this.selected === undefined || this.selected == null)
        return;

      this.alertService.clear();

      for (var i=0; i<this.selected.length; i++)
      {
          for (var j=0; j<this.reposList.length; j++)
          {
              if (this.reposList[j].id == this.selected[i])
              {
                this.favoriteRepos.push(this.reposList[j])
              } 
          }
      }

      this.repositoryService.postFavorites(this.favoriteRepos)
            .pipe(first())
            .subscribe(
                data => {
                  console.log(data)
                  this.alertService.success('Saved successfully', { keepAfterRouteChange: true });
                },
                error => {
                  console.log(error)
                });
    }

}

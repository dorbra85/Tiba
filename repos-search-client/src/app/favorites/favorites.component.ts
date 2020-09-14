import { Component, OnInit } from '@angular/core';
import { RepositoryService } from '@app/_services/repository.service';
import { first } from 'rxjs/operators';


export interface PeriodicElement {
  name: string;
  fullname: string;
}


@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.less']
})
export class FavoritesComponent implements OnInit {

  displayedColumns: string[] = ['name', 'fullname'];
  dataSource = [];

  constructor( private repositoryService: RepositoryService
    ) { }

  ngOnInit(): void {

    this.repositoryService.getFavorites()
    .pipe(first())
    .subscribe(
        data => {
          console.log(data)
          let searchResults = Object.freeze(data)
          this.dataSource = searchResults.map(result => ({
            name: result.name,
            fullname: result.fullName,
          }));
        },
        error => {
          console.log(error)
        });

  }

}



import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '@environments/environment';
import { Repository } from '@app/_models/repository';
import { User } from '@app/_models';



@Injectable({ providedIn: 'root' })
export class RepositoryService {
     private userSubject: BehaviorSubject<User>;

    constructor(
        private router: Router,
        private http: HttpClient,
    ) {
    }


    getFavorites() {
        var user = JSON.parse(localStorage.getItem('user'))
        var token = user.userDetails.token
        var reqHeader = new HttpHeaders({ 
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
         });
        return this.http.get<Repository[]>(`${environment.apiUrl}/Repository`,{ headers: reqHeader });
    }

    searchTerm(searchTerm: string) {
        var user = JSON.parse(localStorage.getItem('user'))
        var token = user.userDetails.token
        var reqHeader = new HttpHeaders({ 
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
         });
        return this.http.get<Repository[]>(`${environment.apiUrl}/Repository/${searchTerm}`,{ headers: reqHeader });
    }


    postFavorites(repositories: Repository[]) {
        var user = JSON.parse(localStorage.getItem('user'))
        var token = user.userDetails.token
        var reqHeader = new HttpHeaders({ 
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
         });
        return this.http.post(`${environment.apiUrl}/Repository`,repositories,{ headers: reqHeader });
    }

}
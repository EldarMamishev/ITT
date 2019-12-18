import { Injectable } from '@angular/core';
import { User } from './entities/user';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  public static userId = 1;

  constructor() { }

  getUser() : Observable<User> {
    return of(JSON.parse(localStorage.getItem('currentUser')));
  }

}

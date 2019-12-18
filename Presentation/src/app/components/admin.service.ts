import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Family } from '../entities/family';
import { CONNECTION_PATH } from '../constants/default-constants';
import { RequestPersonIdFamilyName } from '../view-models/request-person-id-family-name';
import { PersonFamily } from '../view-models/person-family';
import { FamilyWithPeople } from '../view-models/family-with-people';

const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 

@Injectable({
  providedIn: 'root'
})

export class FamilyService {  
  private root = CONNECTION_PATH + '/family';  

  constructor( 
    private http: HttpClient
  ) { }

  getFamilies() : Observable<Family[]> {
    return this.http.get<Family[]>(this.root, httpOptions);
  }

  getFamilyById(id : number) : Observable<FamilyWithPeople> {
    return this.http.get<FamilyWithPeople>(this.root + id, httpOptions);
  }

  getFamiliesByPersonId(id : number) : Observable<FamilyWithPeople[]> {
    return this.http.get<FamilyWithPeople[]>(this.root + '/person/' + id, httpOptions);
  }

  update(family : Family) : Observable<Family> {
    return this.http.put<Family>(this.root, family);
  }

  createFamilyByPerson(personFamily : RequestPersonIdFamilyName) : Observable<any> {
    return this.http.post(this.root, personFamily, httpOptions);
  }

  addPersonToFamily(personFamily : PersonFamily) : Observable<Family>{
    return this.http.post<Family>(this.root, personFamily);
  }
}

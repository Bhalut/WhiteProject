import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from '../models/person.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  API = environment.API;
  constructor(private http: HttpClient) {}

  public getPersons(): Observable<Person[]> {
    return this.http.get<Person[]>(`${this.API}/api/v1/person`);
  }
}

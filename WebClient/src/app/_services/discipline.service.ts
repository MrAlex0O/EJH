import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DisciplineService {

  constructor(private _http: HttpClient) { }
  public getAllDisciplines() {
    return this._http.get('https://localhost:7287/api/Discipline');
  }
}

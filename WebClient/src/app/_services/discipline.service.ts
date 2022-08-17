import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { DisciplineModel } from '../_models/disciplineModel';

const AUTH_API = environment.api_path + '/Discipline';
@Injectable({
  providedIn: 'root'
})
export class DisciplineService {

  constructor(private _http: HttpClient) { }

  public getAllDisciplines() :Observable<DisciplineModel[]> {
    return this._http.get<DisciplineModel[]>(AUTH_API);
  }
}

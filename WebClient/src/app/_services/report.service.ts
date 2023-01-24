import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { DisciplineVisitsModel } from '../_models/Reports/DisciplineVisitsModel';

const API_PATH = environment.api_path + '/Report';
@Injectable({
  providedIn: 'root'
})
export class ReportService {

  constructor(private _http: HttpClient) { }

  public getAll(id: string): Observable<DisciplineVisitsModel[]> {
    return this._http.get<DisciplineVisitsModel[]>(API_PATH + '/disciplineVisits/' + id);
  }
}

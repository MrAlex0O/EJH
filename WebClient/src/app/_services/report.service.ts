import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { DisciplineVisitsReportModel } from '../_models/Reports/DisciplineVisitsModel';
import { StudentVisitsReportModel } from '../_models/Reports/studentVisitsModel';

const API_PATH = environment.api_path + '/Report';
@Injectable({
  providedIn: 'root'
})
export class ReportService {

  constructor(private _http: HttpClient) { }

  public getDisciplineVisits(id: string): Observable<DisciplineVisitsReportModel[]> {
    return this._http.get<DisciplineVisitsReportModel[]>(API_PATH + '/disciplineVisits/' + id);
  }
  public getStudentVisits(id: string): Observable<StudentVisitsReportModel[]> {
    return this._http.get<StudentVisitsReportModel[]>(API_PATH + '/studentVisits/' + id);
  }
}

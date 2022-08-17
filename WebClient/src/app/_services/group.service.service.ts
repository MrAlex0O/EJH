import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { GroupModel } from '../_models/groupModel';
const AUTH_API = environment.api_path + '/Group';
@Injectable({
  providedIn: 'root'
})
export class GroupService {

  constructor(private _http: HttpClient) { }

  public getAllDisciplines(): Observable<GroupModel[]>{
    return this._http.get<GroupModel[]>(AUTH_API);
  }
}

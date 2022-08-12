import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RegisterModel } from '../_models/registerModel'
import { AuthReponseModel } from '../_models/AuthResponseModel'
import { LoginModel } from '../_models/loginModel'

const AUTH_API = 'https://localhost:7287/api/User/';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) { }

  login(login: LoginModel): Observable<any> {

    return this.http.post(
      AUTH_API + 'login',
      login,
      httpOptions
    );
  }
  register(register: RegisterModel): Observable<any> {
    return this.http.post(
      AUTH_API + 'register',
      register,
      httpOptions
    );
  }
  logout(): Observable<any> {
    return this.http.post(AUTH_API + 'signout', {}, httpOptions);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RegisterModel } from '../_models/registerModel'
import { LoginModel } from '../_models/loginModel'
import { environment } from '../../environments/environment';

const AUTH_API = environment.api_path + '/User';
  //'https://localhost:7287/api/User';
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
      AUTH_API + '/login',
      login,
      httpOptions
    );
  }
  register(register: RegisterModel): Observable<any> {
    return this.http.post(
      AUTH_API + '/register',
      register,
      httpOptions
    );
  }
  logout(): Observable<any> {
    sessionStorage.removeItem("auth-user");
    return this.http.post(AUTH_API + '/signout', {}, httpOptions);
  }
}

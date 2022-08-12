import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { StorageService } from '../_services/storage.service';
import { LoginModel } from '../_models/loginModel'
import { AuthReponseModel } from '../_models/AuthResponseModel'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: LoginModel = new LoginModel;
  data: AuthReponseModel = new AuthReponseModel;
  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  roles: string[] = [];
  constructor(private authService: AuthService, private storageService: StorageService) { }
  ngOnInit(): void {
    if (this.storageService.isLoggedIn()) {
      this.isLoggedIn = true;
      this.roles = this.storageService.getUser().roles;
      this.data = this.storageService.getUser();
    }
  }
  onSubmit(): void {
    this.authService.login(this.form).subscribe(
      data => {
        this.data = data;
        this.storageService.saveUser(data);
        this.isLoginFailed = false;
        this.isLoggedIn = true;
        this.roles = this.storageService.getUser().roles;

        console.log("logged as " + data.name);
        console.log(data);
    });
  }
}

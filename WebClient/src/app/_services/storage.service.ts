import { Injectable } from '@angular/core';
const USER_KEY = 'auth-user';
const THEME = 'theme';
@Injectable({
  providedIn: 'root'
})
export class StorageService {
  constructor() { }
  clean(): void {
    window.sessionStorage.clear();
  }
  public saveTheme(theme: string) {

    window.sessionStorage.removeItem(THEME);
    window.sessionStorage.setItem(THEME, theme);
  }

  public getTheme(): any {
    const theme = window.sessionStorage.getItem(THEME);
    if (theme) {
      return theme;
    }
    return 'light';
  }


  public saveUser(user: any): void {
    window.sessionStorage.removeItem(USER_KEY);
    window.sessionStorage.setItem(USER_KEY, JSON.stringify(user));
  }
  public getUser(): any {
    const user = window.sessionStorage.getItem(USER_KEY);
    if (user) {
      return JSON.parse(user);
    }
    return {};
  }
  public getUserToken(): string {
    const user = window.sessionStorage.getItem(USER_KEY);
    if (user) {
      return JSON.parse(user)['token'];
    }
    return "";
  }
  public isLoggedIn(): boolean {
    const user = window.sessionStorage.getItem(USER_KEY);
    if (user) {
      return true;
    }
    return false;
  }
}

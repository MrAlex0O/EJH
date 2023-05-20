import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { StorageService } from '../_services/storage.service';


@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private _storageService: StorageService) {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    let userRoles: string[] = this._storageService.getRoles();
    if (userRoles.length != 0) {
      const { roles } = route.data;
      let intersection: string[] = roles.filter((x: string) => userRoles.includes(x));
      if (intersection.length == 0) {
        this.router.navigate(['/']);
        return false;
      }
      return true;
    }
    this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
    alert('Необходима авторизация');
    return false;
  }
}

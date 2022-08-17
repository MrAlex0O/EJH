import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable } from 'rxjs';
import { StorageService } from '../_services/storage.service';
@Injectable()
export class HttpRequestInterceptor implements HttpInterceptor {
  token: string = "";
  constructor(private _storageService: StorageService) {
    this.token = _storageService.getUserToken();
  }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    req = req.clone({
      withCredentials: true,
      headers: req.headers.set('Authorization', `Bearer ${this.token}`)
    });
    return next.handle(req);
  }
}


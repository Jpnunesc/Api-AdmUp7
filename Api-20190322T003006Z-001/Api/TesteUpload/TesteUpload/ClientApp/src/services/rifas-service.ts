import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { environment } from '../environments/environment';


@Injectable()
export class RifasService {
 private pathUrlService = environment.urlService;
  protected headers: Headers;
  protected requestOptions: RequestOptions;

  constructor(private http: Http) {
    this.headers = new Headers();
    this.headers.append('Content-Type', 'application/json');
    this.requestOptions = new RequestOptions({ headers: this.headers, withCredentials: true });
  }

  search(): Observable<any> {
    return this.http.get(this.pathUrlService + 'carros').map(res => res.json() );
  }
  delete(idEvento: number): Observable<any> {
    return this.http.delete(this.pathUrlService + 'eventos/' + idEvento, this.requestOptions).map(res => res.json());
  }
}
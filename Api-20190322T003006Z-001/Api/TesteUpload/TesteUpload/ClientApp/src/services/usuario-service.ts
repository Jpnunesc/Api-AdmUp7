
import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { environment } from '../environments/environment';


@Injectable()
export class UsuarioService {
 private pathUrlService = environment.urlService;
  protected headers: Headers;
  protected requestOptions: RequestOptions;

  constructor(private http: Http) {
    this.headers = new Headers();
    this.headers.append('Content-Type', 'application/json');
    this.requestOptions = new RequestOptions({ headers: this.headers, withCredentials: true });
  }

  aprovados(): Observable<any> {
    return this.http.get(this.pathUrlService + 'usuario/aprovado').map(res => res.json() );
  }
  pedentes(): Observable<any> {
    return this.http.get(this.pathUrlService + 'Usuario/pendente').map(res => res.json() );
  }
  delete(id: number): Observable<any> {
    return this.http.delete(this.pathUrlService + 'usuario/' + id, this.requestOptions).map(res => res.json());
  } 
  atualizar(): Observable<any> {
    return this.http.get(this.pathUrlService + 'usuario/atualizar', this.requestOptions).map(res => res.json());
  } 
  ganhou(id: number): Observable<any> {
    return this.http.get(this.pathUrlService + 'usuario/ganhou' + id, this.requestOptions).map(res => res.json());
  }
  aprovar(id: number): Observable<any> {
    return this.http.get(this.pathUrlService + 'Usuario/aprovar/' + id, this.requestOptions).map(res => res.json());
  }
  buscarUsuarioPorRifa(id: number): Observable<any> {
    debugger;
    return this.http.get(this.pathUrlService + 'Usuario/rifas/' + id, this.requestOptions).map(res => res.json());
  }
}
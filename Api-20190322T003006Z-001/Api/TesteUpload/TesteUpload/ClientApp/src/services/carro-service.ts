import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { environment } from '../environments/environment';
import { CarroModel } from '../models/carros-model';


@Injectable()
export class CarroService {
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


  delete(idCarro: number): Observable<any> {
    return this.http.delete(this.pathUrlService + '/' + idCarro, this.requestOptions).map(res => res.json());
  }

  edit(idCarro: number): Observable<any> {
    return this.http.get(this.pathUrlService + 'carros/' + idCarro, this.requestOptions).map(res => res.json());
  }

  save(carroModel: CarroModel): Observable<any> {
    return this.http.post(this.pathUrlService + 'carros', carroModel, this.requestOptions).map(res => res.json());
  }

}



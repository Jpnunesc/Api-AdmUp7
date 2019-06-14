import { Component, Inject } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType } from '@angular/common/http';
import { CarroModel } from '../../models/carros-model';

@Component({
  selector: 'app-carro-component',
  templateUrl: './carro.component.html'
})
export class CarroComponent {

  public retorno: string;
  public carro: CarroModel = new CarroModel();
  private baseUrl: string;
  private http: HttpClient;

  private arquivos: FileList;
  private imagemPrincipal: FileList;
  principal = 'ImagemPrincipal';
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }

  salvar() {
    const fd = new FormData();
    for (let i = 0; i < this.arquivos.length; i++) {
      fd.append(this.arquivos[i].name, this.arquivos[i]);
    }

    for (let i = 0; i < this.imagemPrincipal.length; i++) {
      fd.append(this.principal + this.imagemPrincipal[i].name, this.imagemPrincipal[i]);
    }

    fd.append('carro', JSON.stringify(this.carro));

    const uploadReq = new HttpRequest('POST', `${this.baseUrl}api/carros`, fd, {
      reportProgress: true,
    });

    this.http.request(uploadReq).subscribe(event => {
      console.log(event);
      if (event.type === HttpEventType.UploadProgress) {
        console.log(`Progresso: ${Math.round(100 * event.loaded / event.total)}`);
      } else if (event.type === HttpEventType.Response) {
        console.log(`Retorno: ${event.body.toString()}`);
      }
    });
  }

  arquivosSelecionados(event) {
    this.arquivos = event.target.files;
  }

  arquivoPrincipal(event) {
    this.imagemPrincipal = event.target.files;
  }
}


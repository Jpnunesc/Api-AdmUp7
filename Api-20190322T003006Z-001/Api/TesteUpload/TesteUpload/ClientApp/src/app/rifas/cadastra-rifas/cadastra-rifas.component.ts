import { Component, OnInit, Inject } from '@angular/core';
import { RifasModel } from '../../../models/rifas-model';
import { HttpClient, HttpRequest, HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-cadastra-rifas',
  templateUrl: './cadastra-rifas.component.html',
  styleUrls: ['./cadastra-rifas.component.css']
})
export class CadastraRifasComponent implements OnInit {
  rifa: RifasModel = new RifasModel();
  public retorno: string;
  private baseUrl: string;
  private http: HttpClient;
  sucesso = false;

  private arquivos: FileList;
  private imagemPrincipal: FileList;
  principal = 'ImagemPrincipal';
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }

  ngOnInit(): void {

  }
  salvar() {
    const fd = new FormData();
    for (let i = 0; i < this.arquivos.length; i++) {
      fd.append(this.arquivos[i].name, this.arquivos[i]);
    }
    fd.append('rifa', JSON.stringify(this.rifa));

    const uploadReq = new HttpRequest('POST', `${this.baseUrl}api/rifas/cadastro`, fd, {
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
    this.rifa = new RifasModel();
    this.sucesso = true;
    setTimeout(() => this.sucesso = false, 4000);

  }
  arquivosSelecionados(event) {
    this.arquivos = event.target.files;
  }
}

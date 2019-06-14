import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType } from '@angular/common/http';
import { InstituicaoModel } from '../../models/instituicao-model';

@Component({
  selector: 'app-instituicao',
  templateUrl: './instituicao.component.html',
  styleUrls: ['./instituicao.component.css']
})
export class InstituicaoComponent implements OnInit {

  instituicao: InstituicaoModel = new InstituicaoModel();
  public retorno: string;
  private baseUrl: string;
  private http: HttpClient;
  sucesso = false;

  private arquivos: FileList;
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
    fd.append('instituicao', JSON.stringify(this.instituicao));

    const uploadReq = new HttpRequest('POST', `${this.baseUrl}api/instituicao/cadastro`, fd, {
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
    this.instituicao = new InstituicaoModel();
    this.sucesso = true;
    setTimeout(() => this.sucesso = false, 4000);

  }
  arquivosSelecionados(event) {
    this.arquivos = event.target.files;
  }
}


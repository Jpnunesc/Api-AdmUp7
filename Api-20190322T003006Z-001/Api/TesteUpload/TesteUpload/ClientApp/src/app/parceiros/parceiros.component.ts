import { Component, OnInit, Inject } from '@angular/core';
import { ParceiroModel } from '../../models/parceiro-model';
import { HttpClient, HttpRequest, HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-parceiros',
  templateUrl: './parceiros.component.html',
  styleUrls: ['./parceiros.component.css']
})
export class ParceirosComponent implements OnInit {

 
  parceiro: ParceiroModel = new ParceiroModel();
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
    debugger;
    fd.append('parceiro', JSON.stringify(this.parceiro));

    const uploadReq = new HttpRequest('POST', `${this.baseUrl}api/parceiro/cadastro`, fd, {
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
    this.parceiro = new ParceiroModel();
    this.sucesso = true;
    setTimeout(() => this.sucesso = false, 4000);

  }
  arquivosSelecionados(event) {
    this.arquivos = event.target.files;
  }
}


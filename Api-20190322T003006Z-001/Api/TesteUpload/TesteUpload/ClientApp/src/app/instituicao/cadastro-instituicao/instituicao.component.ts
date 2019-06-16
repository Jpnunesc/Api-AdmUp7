import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType } from '@angular/common/http';
import { InstituicaoModel } from '../../../models/instituicao-model';
import { InstituicaoService } from '../../../services/intituicao-service';
import { Router, ActivatedRoute } from '@angular/router';

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
  edit = false;
  msg = false;
  private arquivos: FileList;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,
  private route: ActivatedRoute, private router: Router, private serviceInstituicao: InstituicaoService) {
    this.baseUrl = baseUrl;
    this.http = http;
  }
 
  ngOnInit() {
    if (this.route.params) {
      this.route.params.subscribe(params => {
        if (params['id']) {
          this.edit = true;
          this.editar(params['id']);
        }
      });
    } else {
      this.edit = false;
    }
  }
  atualizarRota() {
    if (!this.edit) {
      this.router.navigate(['../listaInstituicao']);
    } else {
      this.router.navigate(['../../listaInstituicao']);
    }
  }
  salvar() {
    if (this.instituicao.nome && this.arquivos) {
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
   } else {
      this.msg = true;
      setTimeout(() => this.msg = false, 3000);
    }
  }
  arquivosSelecionados(event) {
    this.arquivos = event.target.files;
  }
  editar(id) {
    this.serviceInstituicao.edit(id).subscribe(resp => {
      console.log(resp);
      if (resp.object) {
        this.instituicao = resp.object;
      }
     //setTimeout(() => this.loading = false, 2000);
   });
  }
}


import { Component, OnInit, Inject } from '@angular/core';
import { ParceiroModel } from '../../../models/parceiro-model';
import { HttpClient, HttpRequest, HttpEventType } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ParceiroService } from '../../../services/parceiros-service';

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
  edit = false;
  msg = false;
  private arquivos: FileList;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,
   private route: ActivatedRoute, private router: Router, private serviceEventos: ParceiroService) {
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
      this.router.navigate(['../listaParceiro']);
    } else {
      this.router.navigate(['../../listaParceiro']);
    }
  }
  salvar() {
    if (this.parceiro.nome && this.arquivos) {
    const fd = new FormData();
    for (let i = 0; i < this.arquivos.length; i++) {
      fd.append(this.arquivos[i].name, this.arquivos[i]);
    }
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
  } else {
    this.msg = true;
    setTimeout(() => this.msg = false, 3000);
  }
  }
  arquivosSelecionados(event) {
    this.arquivos = event.target.files;
  }
  editar(id) {
    this.serviceEventos.edit(id).subscribe(resp => {
      console.log(resp);
      if (resp.object) {
        this.parceiro = resp.object;
      }
     //setTimeout(() => this.loading = false, 2000);
   });
  }
}


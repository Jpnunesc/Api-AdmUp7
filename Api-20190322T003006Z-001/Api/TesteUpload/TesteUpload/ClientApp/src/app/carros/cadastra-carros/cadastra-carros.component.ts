
import { CarroModel } from '../../../models/carros-model';
import { Component, Inject, OnInit, ViewContainerRef } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { CarroService } from '../../../services/carro-service';




@Component({
  selector: 'app-cadastra-carros',
  templateUrl: './cadastra-carros.component.html',
  styleUrls: ['./cadastra-carros.component.css']
})
export class CadastraCarrosComponent implements OnInit {

  sucesso = false;
  edit = false;
  public retorno: string;
  public carro: CarroModel = new CarroModel();
  public loading = false;
  private baseUrl: string;
  private http: HttpClient;

  private arquivos: FileList;
  private imagemPrincipal: FileList;
  principal = 'ImagemPrincipal';
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, vcr: ViewContainerRef,
    private serviceCarro: CarroService, private route: ActivatedRoute, private router: Router) {
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
  salvar() {
    this.loading = true;
    const fd = new FormData();
    console.log(this.arquivos);
    if (this.arquivos !== null && this.arquivos !== undefined) {
      for (let i = 0; i < this.arquivos.length; i++) {
        fd.append(this.arquivos[i].name, this.arquivos[i]);
      }
    }
    if (this.imagemPrincipal !== null && this.imagemPrincipal !== undefined) {
      for (let i = 0; i < this.imagemPrincipal.length; i++) {
        fd.append(this.principal + this.imagemPrincipal[i].name, this.imagemPrincipal[i]);
      }
    }
    fd.append('carro', JSON.stringify(this.carro));
    const uploadReq = new HttpRequest('POST', `${this.baseUrl}api/carros`, fd, {
      reportProgress: true,
    });
    this.http.request(uploadReq).subscribe(event => {
      
      if (event.type === HttpEventType.UploadProgress) {
        if (`${Math.round(100 * event.loaded / event.total)}` === '100') {
          setTimeout(() => this.sucesso = false, 2000);
          setTimeout(() => this.loading = false, 3000);
          setTimeout(() => this.atualizarRota(), 1000);
        }
        console.log(`Progresso: ${Math.round(100 * event.loaded / event.total)}`);
      } else if (event.type === HttpEventType.Response) {
        if (`${event.body.toString()}` === 'sucess') {
          this.sucesso = true;
          setTimeout(() => this.sucesso = false, 2000);
          setTimeout(() => this.loading = false, 3000);
          setTimeout(() => this.atualizarRota(), 1000);
        }
      }
      this.carro = new CarroModel();
    });
  }
  atualizarRota() {
    if (!this.edit) {
      this.router.navigate(['../listaCarro']);
    } else {
      this.router.navigate(['../../listaCarro']);
    }
  }
  arquivosSelecionados(event) {
    this.arquivos = event.target.files;
  }

  arquivoPrincipal(event) {
    this.imagemPrincipal = event.target.files;
  }
  editar(id) {
    this.loading = true;
    console.log(id);
    this.serviceCarro.edit(id).subscribe(resp => {
      console.log(resp);
      if (resp.object) {
        this.carro = resp.object;
      }
      setTimeout(() => this.loading = false, 2000);
    });
  }
}



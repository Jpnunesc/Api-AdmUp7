import { Component, OnInit, Inject } from '@angular/core';
import { EventoModel } from '../../../models/eventos-model';
import { HttpClient, HttpRequest, HttpEventType } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { EventosService } from '../../../services/eventos-services';

@Component({
  selector: 'app-cadastra-eventos',
  templateUrl: './cadastra-eventos.component.html',
  styleUrls: ['./cadastra-eventos.component.css']
})
export class CadastraEventosComponent implements OnInit {

  evento: EventoModel = new EventoModel();
  public retorno: string;
  private baseUrl: string;
  private http: HttpClient; 
  sucesso = false;
  edit = false;
  msg = false;

  private arquivos: FileList;
  private imagemPrincipal: FileList;
  principal = 'ImagemPrincipal';
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,
   private route: ActivatedRoute, private router: Router, private serviceEventos: EventosService) {
    this.baseUrl = baseUrl;
    this.http = http;
  }

  ngOnInit(): void {
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
      this.router.navigate(['../listaEvento']);
    } else {
      this.router.navigate(['../../listaEvento']);
    }
  }
  salvar() {
    if (this.evento.mes && this.arquivos) {
      const fd = new FormData();
      for (let i = 0; i < this.arquivos.length; i++) {
        fd.append(this.arquivos[i].name, this.arquivos[i]);
      }
      fd.append('evento', JSON.stringify(this.evento));
  
      const uploadReq = new HttpRequest('POST', `${this.baseUrl}api/eventos/cadastro`, fd, {
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
      this.evento = new EventoModel();
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
        this.evento = resp.object;
      }
     //setTimeout(() => this.loading = false, 2000);
   });
  }
}


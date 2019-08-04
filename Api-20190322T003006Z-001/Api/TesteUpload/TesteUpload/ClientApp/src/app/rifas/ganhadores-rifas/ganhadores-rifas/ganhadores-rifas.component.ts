import { Component, OnInit } from '@angular/core';
import { UsuarioModel } from '../../../../models/usuario-model';
import { ConfirmComponent } from '../../../../shared/componet';
import { RifasModel } from '../../../../models/rifas-model';
import { DialogService } from 'ng2-bootstrap-modal';
import { RifasService } from '../../../../services/rifas-service';
import { UsuarioService } from '../../../../services/usuario-service';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-ganhadores-rifas',
  templateUrl: './ganhadores-rifas.component.html',
  styleUrls: ['./ganhadores-rifas.component.css']
})
export class GanhadoresRifasComponent implements OnInit {

  public loading = false;
  formSearch: UsuarioModel[] = new Array<UsuarioModel>();
  urlPrincipal = '';
  url = environment.urlImagem;
  showModal = false;
  sucesso = false;
  idRifa: any;
  arrRifas: RifasModel[] = new Array<RifasModel>();
  constructor(private serviceUsuario: UsuarioService, private dialogService: DialogService
    , private serviceRifas: RifasService) { }

  ngOnInit() {
    this.search();
    this.getRifas();
  }
  getRifas() {
    this.arrRifas = new Array<RifasModel>();
    this.loading = true;
    this.serviceRifas.search().subscribe(resp => {
      if (resp.object.length) {
        console.log(resp);
        this.arrRifas = resp.object;
      }
      setTimeout(() => this.loading = false, 2000);
    }, error => console.log(error),
      () => console.log('error.'));
    setTimeout(() => this.loading = false, 2000);
  }
  showConfirmAprovar(id) {
    this.dialogService.addDialog(ConfirmComponent, {
      title: 'Alerta!',
      message: 'Deseja realmente confirmar?'
    })
      .subscribe((isConfirmed) => {
        if (isConfirmed) {
          this.aprovar(id);
        } else {
        }
      });
  }
  showConfirmExcluir(id) {
    this.dialogService.addDialog(ConfirmComponent, {
      title: 'Alerta!',
      message: 'Deseja excluir?'
    })
      .subscribe((isConfirmed) => {
        if (isConfirmed) {
          this.excluir(id);
        } else {
        }
      });
  }
  excluir(id) {
    this.serviceUsuario.delete(id).subscribe(resp => {
      if (resp) {
       // this.sucesso = true;
        setTimeout(() => {
        //  this.sucesso = false;
        }, 10000);
      }
      this.search();
    });
  }
  aprovar(id) {
    this.serviceUsuario.aprovar(id).subscribe(resp => {
      if (resp) {
          this.search();
      }
    });
  }
  search() {
    this.formSearch = new Array<UsuarioModel>();
    this.loading = true;
    this.serviceUsuario.pedentes().subscribe(resp => {
      if (resp.object.length) {
        this.formSearch = resp.object;
        this.formSearch.forEach(el => {
          el.rifa.imagem = this.url + el.rifa.imagem;
        });
        console.log('img', this.formSearch);
      }
      setTimeout(() => this.loading = false, 2000);
    }, error => console.log(error),
      () => console.log('error.'));
    setTimeout(() => this.loading = false, 2000);
  }
}
import { Component, OnInit } from '@angular/core';
import { UsuarioModel } from '../../../models/usuario-model';
import { ConfirmComponent } from '../../../shared/componet';
import { UsuarioService } from '../../../services/usuario-service';
import { DialogService } from 'ng2-bootstrap-modal';
import { RifasModel } from '../../../models/rifas-model';
import { RifasService } from '../../../services/rifas-service';

@Component({
  selector: 'app-pendentes-rifas',
  templateUrl: './pendentes-rifas.component.html',
  styleUrls: ['./pendentes-rifas.component.css']
})
export class PendentesRifasComponent implements OnInit {
  public loading = false;
  formSearch: UsuarioModel[] = new Array<UsuarioModel>();
  urlPrincipal = '';
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
buscar() {
  this.formSearch = new Array<UsuarioModel>();
  if (this.idRifa) {
    this.serviceUsuario.buscarUsuarioPorRifaPendente(Number(this.idRifa)).subscribe(resp => {
      console.log(resp);
      if (resp.object) {
        this.formSearch = resp.object;
      }
   });
  }
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
  atualizar(){
    this.serviceUsuario.atualizar().subscribe(resp => {
      if (resp) {
       // this.sucesso = true;
        setTimeout(() => {
        //  this.sucesso = false;
        }, 10000);
      }
      this.search();
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
      }
      setTimeout(() => this.loading = false, 2000);
    }, error => console.log(error),
      () => console.log('error.'));
    setTimeout(() => this.loading = false, 2000);
  }
}

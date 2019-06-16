import { Component, OnInit } from '@angular/core';
import { UsuarioModel } from '../../../models/usuario-model';
import { ConfirmComponent } from '../../../shared/componet';
import { UsuarioService } from '../../../services/usuario-service';
import { DialogService } from 'ng2-bootstrap-modal';

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
  constructor(private serviceUsuario: UsuarioService, private dialogService: DialogService) { }

  ngOnInit() {
    this.search();
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
       // this.sucesso = true;
        setTimeout(() => {
        //  this.sucesso = false;
        }, 10000);
      }
      this.search();
    });
  }
  search() {
    debugger;
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

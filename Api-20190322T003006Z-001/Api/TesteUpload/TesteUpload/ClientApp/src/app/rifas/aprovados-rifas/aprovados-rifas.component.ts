import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { UsuarioModel } from '../../../models/usuario-model';
import { DialogService } from 'ng2-bootstrap-modal';
import { ConfirmComponent } from '../../../shared/componet';
import { UsuarioService } from '../../../services/usuario-service';

@Component({
  selector: 'app-aprovados-rifas',
  templateUrl: './aprovados-rifas.component.html',
  styleUrls: ['./aprovados-rifas.component.css']
})
export class AprovadosRifasComponent implements OnInit {
  public loading = false;
  formSearch: UsuarioModel[] = new Array<UsuarioModel>();
  urlPrincipal = '';
  showModal = false;
  sucesso = false;
  constructor(private serviceRifas: UsuarioService, private dialogService: DialogService) { }

  ngOnInit() {
    this.search();
  }

  showConfirmGanhou(id) {
    this.dialogService.addDialog(ConfirmComponent, {
      title: 'Alerta!',
      message: 'Deseja realmente confirmar?'
    })
      .subscribe((isConfirmed) => {
        if (isConfirmed) {
          this.ganhou(id);
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
    this.serviceRifas.delete(id).subscribe(resp => {
      if (resp) {
       // this.sucesso = true;
        setTimeout(() => {
        //  this.sucesso = false;
        }, 10000);
      }
      this.search();
    });
  }
  ganhou(id) {
    this.serviceRifas.ganhou(id).subscribe(resp => {
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
    this.formSearch = new Array<UsuarioModel>();
    this.loading = true;
    this.serviceRifas.aprovados().subscribe(resp => {
      if (resp.object.length) {
        this.formSearch = resp.object;
      }
      setTimeout(() => this.loading = false, 2000);
    }, error => console.log(error),
      () => console.log('error.'));
    setTimeout(() => this.loading = false, 2000);
  }
}

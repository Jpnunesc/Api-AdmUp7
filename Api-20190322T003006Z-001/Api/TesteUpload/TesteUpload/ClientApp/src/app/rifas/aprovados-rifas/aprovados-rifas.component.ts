import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { UsuarioModel } from '../../../models/usuario-model';
import { DialogService } from 'ng2-bootstrap-modal';
import { ConfirmComponent } from '../../../shared/componet';
import { UsuarioService } from '../../../services/usuario-service';
import { RifasModel } from '../../../models/rifas-model';
import { RifasService } from '../../../services/rifas-service';

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
  idRifa: any;
  arrRifas: RifasModel[] = new Array<RifasModel>();
  constructor(private serviceUsuario: UsuarioService, private serviceRifas: RifasService
   , private dialogService: DialogService) { }

  ngOnInit() {
    this.search();
    this.getRifas();
  }

  showConfirmGanhou(id) {
    this.dialogService.addDialog(ConfirmComponent, {
      title: 'Alerta!',
      message: 'Deseja realmente confirmar?'
    })
      .subscribe((isConfirmed) => {
        if (isConfirmed) {
       //   this.ganhou(id);
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
  ganhou(id) {
    this.serviceUsuario.ganhou(id).subscribe(resp => {
      if (resp) {
       // this.sucesso = true;
        setTimeout(() => {
        //  this.sucesso = false;
        }, 10000);
      }
      this.search();
    });
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
    debugger;
    this.formSearch = new Array<UsuarioModel>();
    if (this.idRifa && this.idRifa !== 'Selecione o codígo da rifa...') {
      this.serviceUsuario.buscarUsuarioPorRifa(Number(this.idRifa)).subscribe(resp => {
        console.log(resp);
        if (resp.object) {
          this.formSearch = resp.object;
        }
     });
    }
  }
  search() {
    this.formSearch = new Array<UsuarioModel>();
    this.loading = true;
    this.serviceUsuario.aprovados().subscribe(resp => {
      if (resp.object.length) {
        this.formSearch = resp.object;
      }
      setTimeout(() => this.loading = false, 2000);
    }, error => console.log(error),
      () => console.log('error.'));
    setTimeout(() => this.loading = false, 2000);
  }
}

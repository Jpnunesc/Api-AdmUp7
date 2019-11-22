import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { EventosService } from '../../../services/eventos-services';
import { DialogService } from 'ng2-bootstrap-modal';
import { ConfirmComponent } from '../../../shared/componet';
import { EventoModel } from '../../../models/eventos-model';

@Component({
  selector: 'app-lista-eventos',
  templateUrl: './lista-eventos.component.html',
  styleUrls: ['./lista-eventos.component.css']
})
export class ListaEventosComponent implements OnInit {
  public loading = false;
  formSearch: EventoModel[] = new Array<EventoModel>();
  showModal = false;
  sucesso = false;
  constructor(private serviceEventos: EventosService, private dialogService: DialogService) { }

  ngOnInit() {
    this.search();
  }

  showConfirm(id) {
    this.dialogService.addDialog(ConfirmComponent, {
      title: 'Alerta!',
      message: 'Deseja realmente excluir?'
    })
      .subscribe((isConfirmed) => {
        if (isConfirmed) {
          this.excluir(id);
        } else {
        }
      });
  }
  excluir(id) {
    this.serviceEventos.delete(id).subscribe(resp => {
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
    this.formSearch = new Array<EventoModel>();
    this.loading = true;
    this.serviceEventos.search().subscribe(resp => {
      if (resp.object.length) {
        this.formSearch = resp.object;
      }
      setTimeout(() => this.loading = false, 2000);
    }, error => console.log(error),
      () => console.log('error.'));
    setTimeout(() => this.loading = false, 2000);
  }

}

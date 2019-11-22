import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { InstituicaoModel } from '../../../models/instituicao-model';
import { DialogService } from 'ng2-bootstrap-modal';
import { ConfirmComponent } from '../../../shared/componet';
import { InstituicaoService } from '../../../services/intituicao-service';

@Component({
  selector: 'app-lista-instituicao',
  templateUrl: './lista-instituicao.component.html',
  styleUrls: ['./lista-instituicao.component.css']
})
export class ListaInstituicaoComponent implements OnInit {
  public loading = false;
  formSearch: InstituicaoModel[] = new Array<InstituicaoModel>();
  showModal = false;
  sucesso = false;
  constructor(private serviceInstituicao: InstituicaoService, private dialogService: DialogService) { }

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
    this.serviceInstituicao.delete(id).subscribe(resp => {
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
    this.formSearch = new Array<InstituicaoModel>();
    this.loading = true;
    this.serviceInstituicao.search().subscribe(resp => {
      if (resp.object.length) {
        this.formSearch = resp.object;
      }
      setTimeout(() => this.loading = false, 2000);
    }, error => console.log(error),
      () => console.log('error.'));
    setTimeout(() => this.loading = false, 2000);
  }

}
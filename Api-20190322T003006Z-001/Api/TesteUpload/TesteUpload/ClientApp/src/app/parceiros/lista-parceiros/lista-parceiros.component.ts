import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { ParceiroModel } from '../../../models/parceiro-model';
import { ConfirmComponent } from '../../../shared/componet';
import { DialogService } from 'ng2-bootstrap-modal';
import { ParceiroService } from '../../../services/parceiros-service';

@Component({
  selector: 'app-lista-parceiros',
  templateUrl: './lista-parceiros.component.html',
  styleUrls: ['./lista-parceiros.component.css']
})
export class ListaParceirosComponent implements OnInit {
  public loading = false;
  formSearch: ParceiroModel[] = new Array<ParceiroModel>();
  showModal = false;
  sucesso = false;
  constructor(private serviceParceiro: ParceiroService, private dialogService: DialogService) { }

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
    this.serviceParceiro.delete(id).subscribe(resp => {
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
    this.formSearch = new Array<ParceiroModel>();
    this.loading = true;
    this.serviceParceiro.search().subscribe(resp => {
      if (resp.object.length) {
        this.formSearch = resp.object;
      }
      setTimeout(() => this.loading = false, 2000);
    }, error => console.log(error),
      () => console.log('error.'));
    setTimeout(() => this.loading = false, 2000);
  }

}


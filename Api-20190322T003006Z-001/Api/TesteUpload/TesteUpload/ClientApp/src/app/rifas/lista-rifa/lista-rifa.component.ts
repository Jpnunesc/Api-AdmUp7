import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { RifasModel } from '../../../models/rifas-model';
import { RifasService } from '../../../services/rifas-service';
import { DialogService } from 'ng2-bootstrap-modal';
import { ConfirmComponent } from '../../../shared/componet';

@Component({
  selector: 'app-lista-rifa',
  templateUrl: './lista-rifa.component.html',
  styleUrls: ['./lista-rifa.component.css']
})
export class ListaRifaComponent implements OnInit {
  url = environment.urlImagem;
  public loading = false;
  formSearch: RifasModel[] = new Array<RifasModel>();
  urlPrincipal = '';
  showModal = false;
  sucesso = false;
  constructor(private serviceRifas: RifasService, private dialogService: DialogService) { }

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
  search() {
    this.formSearch = new Array<RifasModel>();
    this.loading = true;
    this.serviceRifas.search().subscribe(resp => {
      if (resp.object.length) {
        this.formSearch = resp.object;
        this.formSearch.forEach(el => {
          el.imagem = this.url + el.imagem;
        });
        // for (let i = 0; i < 10; i++) {
        //   this.formSearchCarro.push(this.formSearchCarro[1]);
        // }
      }
      setTimeout(() => this.loading = false, 2000);
    }, error => console.log(error),
      () => console.log('error.'));
    setTimeout(() => this.loading = false, 2000);
  }

}

import { Component, OnInit } from '@angular/core';
import { CarroModel } from '../../../models/carros-model';
import { CarroService } from '../../../services/carro-service';
import { environment } from '../../../environments/environment';
import { DialogService } from 'ng2-bootstrap-modal';
import { ConfirmComponent } from '../../../shared/componet';

@Component({
  selector: 'app-lista-carros',
  templateUrl: './lista-carros.component.html',
  styleUrls: ['./lista-carros.component.css']
})
export class ListaCarrosComponent implements OnInit {
  url = environment.urlImagem;
  public loading = false;
  formSearchCarro: CarroModel[] = new Array<CarroModel>();
  urlPrincipal = '';
  showModal = false;

  constructor(private serviceCarro: CarroService, private dialogService: DialogService) {
  }

  ngOnInit() {
    this.search();
  }

  showConfirm() {
    debugger;
    let disposable = this.dialogService.addDialog(ConfirmComponent, {
      title: 'Confirm title',
      message: 'Confirm message'
    })
      .subscribe((isConfirmed) => {
        if (isConfirmed) {
          alert('accepted');
        }
        else {
          alert('declined');
        }
      });
    setTimeout(() => {
      disposable.unsubscribe();
    }, 10000);
  }
  search() {
    this.loading = true;
    this.serviceCarro.search().subscribe(resp => {
      if (resp.object.length) {
        this.formSearchCarro = resp.object;
        this.formSearchCarro.forEach(el => {
          el.caminhoImgPrincipal = this.url + el.caminhoImagem;
        });
        for (let i = 0; i < 10; i++) {
          this.formSearchCarro.push(this.formSearchCarro[1]);
        }
        console.log(this.formSearchCarro);
      }
      setTimeout(() => this.loading = false, 2000);
    }, error => console.log(error),
      () => console.log('error.'));
    setTimeout(() => this.loading = false, 2000);
  }
}



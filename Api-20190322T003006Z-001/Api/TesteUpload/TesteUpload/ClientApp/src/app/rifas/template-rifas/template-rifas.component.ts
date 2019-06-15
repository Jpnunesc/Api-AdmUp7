import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-template-rifas',
  templateUrl: './template-rifas.component.html',
  styleUrls: ['./template-rifas.component.css']
})
export class TemplateRifasComponent implements OnInit {
  aprovado = false;
  pendente = false;
  rifas = true;
  constructor() { }

  ngOnInit() {
  }

  navegar(el) {
    debugger;
    if (el.currentTarget.id === '3') {
      this.rifas = false;
      this.pendente = false;
      this.aprovado = true;
    } else if (el.currentTarget.id === '2') {
      this.rifas = false;
      this.aprovado = false;
      this.pendente = true;
    } else if (el.currentTarget.id === '1') {
      this.pendente = false;
      this.aprovado = false;
      this.rifas = true;
    }
  }
}

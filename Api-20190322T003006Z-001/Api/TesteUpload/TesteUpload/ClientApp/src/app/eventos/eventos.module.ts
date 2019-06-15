import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CadastraEventosComponent } from './cadastra-eventos/cadastra-eventos.component';
import { ListaEventosComponent } from './lista-eventos/lista-eventos.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [CadastraEventosComponent, ListaEventosComponent]
})
export class EventosModule { }

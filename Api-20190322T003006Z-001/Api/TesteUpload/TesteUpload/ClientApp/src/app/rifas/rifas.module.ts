import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CadastraRifasComponent } from './cadastra-rifas/cadastra-rifas.component';
import { TemplateRifasComponent } from './template-rifas/template-rifas.component';
import { ListaRifaComponent } from './lista-rifa/lista-rifa.component';
import { AprovadosRifasComponent } from './aprovados-rifas/aprovados-rifas.component';
import { PendentesRifasComponent } from './pendentes-rifas/pendentes-rifas.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [CadastraRifasComponent, TemplateRifasComponent, ListaRifaComponent, AprovadosRifasComponent, PendentesRifasComponent]
})
export class RifasModule { }

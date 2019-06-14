import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListaCarrosComponent } from './lista-carros/lista-carros.component';
import { CadastraCarrosComponent } from './cadastra-carros/cadastra-carros.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

@NgModule({
  imports: [
    CommonModule,
    BrowserAnimationsModule
  ],
  declarations: [ListaCarrosComponent, CadastraCarrosComponent],
})
export class CarrosModule { }

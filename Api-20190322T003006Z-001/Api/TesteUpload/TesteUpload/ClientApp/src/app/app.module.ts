import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ListaCarrosComponent } from './carros/lista-carros/lista-carros.component';
import { CadastraCarrosComponent } from './carros/cadastra-carros/cadastra-carros.component';
 import { CarroService } from '../services/carro-service';
import { HttpModule } from '@angular/http';
import { CadastraEventosComponent } from './eventos/cadastra-eventos/cadastra-eventos.component';
import { CadastraRifasComponent } from './rifas/cadastra-rifas/cadastra-rifas.component';
import { ParceirosComponent } from './parceiros/parceiros.component';
import { InstituicaoComponent } from './instituicao/instituicao.component';
import { LoginComponent } from './login/login.component';
import { AuthService } from './login/login/auth.service';
import { AuthGuard } from './guards/auth-guard';
import { BootstrapModalModule } from 'ng2-bootstrap-modal';
import { ConfirmComponent } from '../shared/componet';




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ListaCarrosComponent,
    CadastraCarrosComponent,
    CadastraEventosComponent,
    CadastraRifasComponent,
    ParceirosComponent,
    InstituicaoComponent,
    LoginComponent,
    ConfirmComponent


  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpModule,
   // BootstrapModalModule,
   BootstrapModalModule.forRoot({container: document.body}),
    FormsModule,
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
      { path: 'counter', component: CounterComponent, canActivate: [AuthGuard] },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthGuard] },
      { path: 'carros', component: CadastraCarrosComponent, canActivate: [AuthGuard] },
      { path: 'eventos', component: CadastraEventosComponent, canActivate: [AuthGuard] },
      { path: 'parceiro', component: ParceirosComponent, canActivate: [AuthGuard] },
      { path: 'instituicao', component: InstituicaoComponent, canActivate: [AuthGuard] },
      { path: 'rifas', component: CadastraRifasComponent, canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent },
      { path: '', component: LoginComponent },
      {path: 'listaCarro', component: ListaCarrosComponent, canActivate: [AuthGuard]},
      { path: 'editarCarro/:id', component: CadastraCarrosComponent, canActivate: [AuthGuard] },
      // { path: 'login', component: LoginComponent },
    ])
  ],
  entryComponents: [
    ConfirmComponent
  ],
  providers: [CarroService, AuthService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }

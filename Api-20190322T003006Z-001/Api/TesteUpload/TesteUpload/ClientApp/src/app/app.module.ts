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
import { LoginComponent } from './login/login.component';
import { AuthService } from './login/login/auth.service';
import { AuthGuard } from './guards/auth-guard';
import { BootstrapModalModule } from 'ng2-bootstrap-modal';
import { ConfirmComponent } from '../shared/componet';
import { ListaEventosComponent } from './eventos/lista-eventos/lista-eventos.component';
import { EventosService } from '../services/eventos-services';
import { ListaParceirosComponent } from './parceiros/lista-parceiros/lista-parceiros.component';
import { ParceirosComponent } from './parceiros/cadastro-parceiros/parceiros.component';
import { ParceiroService } from '../services/parceiros-service';
import { ListaInstituicaoComponent } from './instituicao/lista-instituicao/lista-instituicao.component';
import { InstituicaoComponent } from './instituicao/cadastro-instituicao/instituicao.component';
import { InstituicaoService } from '../services/intituicao-service';
import { TemplateRifasComponent } from './rifas/template-rifas/template-rifas.component';
import { RifasService } from '../services/rifas-service';
import { ListaRifaComponent } from './rifas/lista-rifa/lista-rifa.component';
import { AprovadosRifasComponent } from './rifas/aprovados-rifas/aprovados-rifas.component';
import { PendentesRifasComponent } from './rifas/pendentes-rifas/pendentes-rifas.component';
import { UsuarioService } from '../services/usuario-service';
import { GanhadoresRifasComponent } from './rifas/ganhadores-rifas/ganhadores-rifas/ganhadores-rifas.component';




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
    ConfirmComponent,
    ListaEventosComponent,
    ListaParceirosComponent,
    ListaInstituicaoComponent,
    TemplateRifasComponent,
    CadastraRifasComponent, 
    ListaRifaComponent,
     AprovadosRifasComponent, 
     PendentesRifasComponent,
     GanhadoresRifasComponent


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
      { path: 'rifas', component: TemplateRifasComponent, canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent },
      { path: '', component: LoginComponent },
      {path: 'listaCarro', component: ListaCarrosComponent, canActivate: [AuthGuard]},
      { path: 'editarCarro/:id', component: CadastraCarrosComponent, canActivate: [AuthGuard] },
      { path: 'listaEvento', component: ListaEventosComponent, canActivate: [AuthGuard] },
      { path: 'editarEvento/:id', component: CadastraEventosComponent, canActivate: [AuthGuard] },
      { path: 'listaParceiro', component: ListaParceirosComponent, canActivate: [AuthGuard] },
      { path: 'editarParceiro/:id', component: ParceirosComponent, canActivate: [AuthGuard] },
      { path: 'listaInstituicao', component: ListaInstituicaoComponent, canActivate: [AuthGuard] },
      { path: 'editarInstituicao/:id', component: InstituicaoComponent, canActivate: [AuthGuard] },
      { path: 'cadastroRifa', component: CadastraRifasComponent, canActivate: [AuthGuard] },
      { path: 'editarRifa/:id', component: CadastraRifasComponent, canActivate: [AuthGuard] },
      // { path: 'login', component: LoginComponent }, editarEvento CadastraRifasComponent
    ])
  ],
  entryComponents: [
    ConfirmComponent
  ],
  providers: [CarroService, AuthService, AuthGuard, EventosService, UsuarioService,
     ParceiroService, InstituicaoService, RifasService],
  bootstrap: [AppComponent]
})
export class AppModule { }

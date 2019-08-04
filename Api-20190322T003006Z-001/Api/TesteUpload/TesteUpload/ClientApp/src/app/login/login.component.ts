import { Component, OnInit } from '@angular/core';
import { AuthService } from './login/auth.service';
import { UsuarioModel } from '../../models/usuario-model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  msg = false;
   usuario: UsuarioModel = new UsuarioModel();
  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.authService.mostrarMenuEmitter.subscribe(
     mostrar => {
       if (!mostrar) {
        this.msg = true;
       }
     }
    );
 }
  fazerLogin() {
    this.authService.fazerLogin(this.usuario);
  }
}

import { Injectable, EventEmitter } from '@angular/core';
import { UsuarioModel } from '../../../models/usuario-model';
import { Router } from '@angular/router';

@Injectable()
export class AuthService {
  private usuarioAutenticado = false;
  private rotaValid = false;
  mostrarMenuEmitter = new EventEmitter<boolean>();
  constructor(private router: Router) { }

  fazerLogin(usuario: UsuarioModel) {
    if (usuario.usuario === 'teste' && usuario.senha === '123') {
      this.usuarioAutenticado = true;
      this.mostrarMenuEmitter.emit(true);
      this.router.navigate(['/home']);
    } else {
      this.mostrarMenuEmitter.emit(false);
      this.usuarioAutenticado = false;
    }
  }
  userAutenticado() {

    return  this.usuarioAutenticado;
  }
}

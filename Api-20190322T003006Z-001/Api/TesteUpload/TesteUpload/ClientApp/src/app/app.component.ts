import { Component } from '@angular/core';
import { AuthService } from './login/login/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{
  title = 'app';
  mostraMenu = false;
  constructor(private authService: AuthService) {

  }
  ngOnInit() {
    this.authService.mostrarMenuEmitter.subscribe(
     mostrar => this.mostraMenu = mostrar
    );
  }
}

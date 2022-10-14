import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from './models/identity/Usuario';
import { UsuarioService } from './services/usuario.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ProBarbearia-App';

  //public usuarioservico: UsuarioService,private router: Router
  constructor() {}
  ngOnInit(): void {

   }
   logout(): void {
    // this.usuarioservico.logout();
    // this.router.navigateByUrl('/usuario/logar');
  }


}

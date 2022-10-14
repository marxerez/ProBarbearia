import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EstabelecimentoService } from 'src/app/services/Estabelecimento.service';
import { ThemeService } from 'src/app/services/Theme.service';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-barrasuperior',
  templateUrl: './barrasuperior.component.html',
  styleUrls: ['./barrasuperior.component.scss']
})
export class BarrasuperiorComponent implements OnInit {
  isCollapsed = true;


  constructor(public usuarioservico: UsuarioService,
    public estabelecimentoservico: EstabelecimentoService,
    private router: Router,
    private theme: ThemeService) { }

  ngOnInit(): void {


  }


  logout(): void {
    this.usuarioservico.logout();
    this.estabelecimentoservico.logout();
    this.router.navigateByUrl('/usuario/logar');
  }

  public currentTheme(): string {
    return this.theme.current;
  }

  public selectTheme(value: string): void {
    this.theme.current = value;
  }
}

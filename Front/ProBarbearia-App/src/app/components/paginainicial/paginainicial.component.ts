import { Component, OnInit } from '@angular/core';
import { Estabelecimento } from 'src/app/models/Estabelecimento';
import { Usuario } from 'src/app/models/identity/Usuario';
import { EstabelecimentoService } from 'src/app/services/Estabelecimento.service';
import { UsuarioService } from 'src/app/services/usuario.service';
import { navbarData } from './nav-data';

@Component({
  selector: 'app-paginainicial',
  templateUrl: './paginainicial.component.html',
  styleUrls: ['./paginainicial.component.scss']
})
export class PaginainicialComponent implements OnInit {

  navData = navbarData;
  collapsed = false;
  subMenu = false;
  selected :any;

  constructor(public usuarioservico: UsuarioService,
    public estabelecimentoServico: EstabelecimentoService) { }

  ngOnInit(): void {
    console.log(navbarData);
    this.defineUsuarioAtual();
    this.defineEstabelecimentoAtual();
  }

  defineUsuarioAtual(): void {
    let usuarioAtual: Usuario;

    if (localStorage.getItem('user'))
      usuarioAtual = JSON.parse(localStorage.getItem('user') ?? '{}');
    else
      usuarioAtual = null as any

    if (usuarioAtual)
      this.usuarioservico.defineUsuarioAtual(usuarioAtual);
  }


  defineEstabelecimentoAtual(): void {
    let estabelecimentoAtual: Estabelecimento;

    if (localStorage.getItem('estabelecimento'))
      estabelecimentoAtual = JSON.parse(localStorage.getItem('estabelecimento') ?? '{}');
    else
      estabelecimentoAtual = null as any

    if (estabelecimentoAtual)
      this.estabelecimentoServico.defineEstabelecimentoAtual(estabelecimentoAtual);


  }

  toggleCollapsed(): void {
    this.collapsed = !this.collapsed;

  }
  closeSidenav(): void {
    this.collapsed = !this.collapsed;

  }
  exibemenu(): void {
    this.collapsed = true;
  }
  mostraSubMenu(data: any): void {

    data.active = !data.active;
    console.log(data.active);

  }
}

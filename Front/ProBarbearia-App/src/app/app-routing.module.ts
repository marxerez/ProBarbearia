import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConsultaAgendaComponent } from './components/Cadastros/Agenda/consulta-agenda/consulta-agenda.component';
import { ConsultaServicoComponent } from './components/Cadastros/Servico/consulta-servico/consulta-servico.component';
import { InicioComponent } from './components/inicio/inicio.component';
import { PaineldecontroleComponent } from './components/paineldecontrole/paineldecontrole.component';

import { PaginainicialComponent } from './components/paginainicial/paginainicial.component';

import { LogarUsuarioComponent } from './components/Usuario/logar-usuario/logar-usuario.component';
import { PerfilComponent } from './components/Usuario/perfil/perfil.component';
import { RegistrarUsuarioComponent } from './components/Usuario/registrar-usuario/registrar-usuario.component';
import { UsuarioComponent } from './components/Usuario/usuario.component';
import { AutenticacaoGuard } from './guard/autenticacao.guard';
import { ListaEstabelecimentoUsuarioComponent } from './components/Estabelecimento/lista-estabelecimento-usuario/lista-estabelecimento-usuario.component';
import { AdminComponent } from './components/Admin/admin.component';
import { MarcarAgendaComponent } from './components/Cadastros/Agenda/marcar-agenda/marcar-agenda.component';
import { GerenciaAgendaComponent } from './components/Cadastros/Agenda/gerencia-agenda/gerencia-agenda.component';
import { ConsultaProfissionalComponent } from './components/Cadastros/Profissional/consulta-profissional/consulta-profissional.component';
import { EditaProfissionalComponent } from './components/Cadastros/Profissional/edita-profissional/edita-profissional.component';


const routes: Routes = [

  { path: '', redirectTo: 'pagina/inicio', pathMatch: 'full' },
  {
    path: '',
     runGuardsAndResolvers: 'always',
     canActivate: [AutenticacaoGuard],
    children: [
      {
        path: 'pagina', component: PaginainicialComponent,
        children: [
          { path: 'inicio', component: InicioComponent },
          { path: 'relatorio', component: PaineldecontroleComponent},
          { path: 'cadastro', component: AdminComponent },
          { path: 'profissional', component: ConsultaProfissionalComponent },
          { path: 'profissionalEditar/:id', component: EditaProfissionalComponent },
          { path: 'profissionalEditar', component: EditaProfissionalComponent },
          { path: 'agenda', component: MarcarAgendaComponent },
          { path: 'minhaagenda', component: ConsultaAgendaComponent},
          { path: 'gerenciaagenda', component: GerenciaAgendaComponent},
          { path: 'perfil', component: PerfilComponent },
          { path: 'perfil/:id', component: PerfilComponent },
          { path: '', redirectTo:'inicio', pathMatch:"full" }
        ],
      },
      {path: 'estabelecimentos', component: ListaEstabelecimentoUsuarioComponent},

    ],
  },
  {
    path: 'usuario',
    children: [
      { path: 'logar', component: LogarUsuarioComponent },
      { path: 'registrar', component: RegistrarUsuarioComponent },
    ],
  },

  { path: '**', redirectTo: 'usuario/logar', pathMatch: 'full' },


];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    onSameUrlNavigation: 'reload'
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }

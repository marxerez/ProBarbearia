import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DEFAULT_CURRENCY_CODE, LOCALE_ID, NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { TabsModule } from 'ngx-bootstrap/tabs';

import { TimepickerModule } from 'ngx-bootstrap/timepicker';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
import { NgxCurrencyModule } from 'ngx-currency';

import { DiaSemanaPipe} from  './Pipe/DiaSemana.pipe'
// **************************************************
import ptBr from '@angular/common/locales/pt';
import { registerLocaleData } from '@angular/common';

registerLocaleData(ptBr);
// **************************************************

import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { UsuarioService } from './services/usuario.service';

import { JwtInterceptor } from './interceptors/jwt.interceptor';

import { RegistrarUsuarioComponent } from './components/Usuario/registrar-usuario/registrar-usuario.component';
import { BarrasuperiorComponent } from './components/paginainicial/barrasuperior/barrasuperior.component';
import { CorpopaginaComponent } from './components/paginainicial/corpopagina/corpopagina.component';
import { PaginainicialComponent } from './components/paginainicial/paginainicial.component';
import { ConsultaAgendaComponent } from './components/Cadastros/Agenda/consulta-agenda/consulta-agenda.component';
import { EditaAgendaComponent } from './components/Cadastros/Agenda/edita-agenda/edita-agenda.component';
import { ConsultaEstabelecimentoComponent } from './components/Cadastros/Estabelecimento/consulta-estabelecimento/consulta-estabelecimento.component';
import { EditaEstabelecimentoComponent } from './components/Cadastros/Estabelecimento/edita-estabelecimento/edita-estabelecimento.component';
import { ConsultaServicoComponent } from './components/Cadastros/Servico/consulta-servico/consulta-servico.component';
import { EditaServicoComponent } from './components/Cadastros/Servico/edita-servico/edita-servico.component';
import { ConsultaUsuarioComponent } from './components/Cadastros/Usuario/consulta-usuario/consulta-usuario.component';
import { EditaUsuarioComponent } from './components/Cadastros/Usuario/edita-usuario/edita-usuario.component';
import { LogarUsuarioComponent } from './components/Usuario/logar-usuario/logar-usuario.component';
import { UsuarioComponent } from './components/Usuario/usuario.component';
import { PaineldecontroleComponent } from './components/paineldecontrole/paineldecontrole.component';
import { InicioComponent } from './components/inicio/inicio.component';
import { NavSuperiorComponent } from './components/paginainicial/nav-superior/nav-superior.component';
import { PerfilComponent } from './components/Usuario/perfil/perfil.component';
import { PerfilDetalheComponent } from './components/Usuario/perfil/perfil-detalhe/perfil-detalhe.component';
import { ThemeService } from './services/Theme.service';
import { ListaEstabelecimentoUsuarioComponent } from './components/Estabelecimento/lista-estabelecimento-usuario/lista-estabelecimento-usuario.component';
import { AdminComponent } from './components/Admin/admin.component';
import { MarcarAgendaComponent } from './components/Cadastros/Agenda/marcar-agenda/marcar-agenda.component';
import { EstabelecimentoService } from './services/Estabelecimento.service';
import { EstadoService } from './services/Estado.service';
import { AgendaService } from './services/Agenda.service';
import { CidadeService } from './services/Cidade.service';
import { EstabelecimentoUsuarioService } from './services/EstabelecimentoUsuario.service';
import { ProfissionalService } from './services/Profissional.service';
import { ProfissionalHorarioService } from './services/ProfissionalHorario.service';
import { ServicoService } from './services/Servico.service';
import { ServicoProfissionalService } from './services/ServicoProfissional.service';
import { GerenciaAgendaComponent } from './components/Cadastros/Agenda/gerencia-agenda/gerencia-agenda.component';
import { ModalGravaAgendaComponent } from './components/Cadastros/Agenda/modal-grava-agenda/modal-grava-agenda.component';
import { ConsultaProfissionalComponent } from './components/Cadastros/Profissional/consulta-profissional/consulta-profissional.component';
import { EditaProfissionalComponent } from './components/Cadastros/Profissional/edita-profissional/edita-profissional.component';
import { EditaHorarioProfissionalComponent } from './components/Cadastros/HorarioProfissional/edita-horario-profissional/edita-horario-profissional.component';
import { ServicoProfissionalComponent } from './components/Cadastros/Servico/servico-profissional/servico-profissional.component';




defineLocale('pt-br', ptBrLocale);

@NgModule({
  declarations: [
    AppComponent,
    DiaSemanaPipe,
    LogarUsuarioComponent,
    RegistrarUsuarioComponent,
    PerfilComponent,
    BarrasuperiorComponent,
    CorpopaginaComponent,
    PaginainicialComponent,
    ConsultaAgendaComponent,
    EditaAgendaComponent,
    ConsultaEstabelecimentoComponent,
    EditaEstabelecimentoComponent,
    ConsultaServicoComponent,
    EditaServicoComponent,
    ConsultaUsuarioComponent,
    EditaUsuarioComponent,
    LogarUsuarioComponent,
    UsuarioComponent,
    PaineldecontroleComponent,
    InicioComponent,
    NavSuperiorComponent,
    PerfilDetalheComponent,
    ListaEstabelecimentoUsuarioComponent,
    AdminComponent,
    MarcarAgendaComponent,
    GerenciaAgendaComponent,
    ModalGravaAgendaComponent,
    ConsultaProfissionalComponent,
    EditaProfissionalComponent,
    EditaHorarioProfissionalComponent,
    ServicoProfissionalComponent,


  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    PaginationModule.forRoot(),
    TabsModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 4000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true,
    }),
    NgxSpinnerModule,
    NgxCurrencyModule,
    TimepickerModule.forRoot(),
  ],
  providers: [
    UsuarioService,
    ThemeService,
    AgendaService,
    CidadeService,
    EstabelecimentoService,
    EstabelecimentoUsuarioService,
    EstadoService,
    ProfissionalService,
    ProfissionalHorarioService,
    ServicoService,
    ServicoProfissionalService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: LOCALE_ID, useValue: 'pt' },
    { provide: DEFAULT_CURRENCY_CODE, useValue: 'BRL' },

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Agenda } from 'src/app/models/Agenda';
import { AgendaUsuario } from 'src/app/models/AgendaUsuario';
import { Estabelecimento } from 'src/app/models/Estabelecimento';
import { Usuario } from 'src/app/models/identity/Usuario';
import { AgendaService } from 'src/app/services/Agenda.service';
import { EstabelecimentoService } from 'src/app/services/Estabelecimento.service';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-consulta-agenda',
  templateUrl: './consulta-agenda.component.html',
  styleUrls: ['./consulta-agenda.component.scss']
})
export class ConsultaAgendaComponent implements OnInit {

  public estabelecimento = {} as Estabelecimento | null;
  public usuario = {} as Usuario;
  public Agendas: AgendaUsuario[] = [];
  public modalRef!: BsModalRef;
  public agenda = {} as Agenda;
  id: number=0;

  constructor(private agendaService: AgendaService,
   private estabelecimentoServico: EstabelecimentoService,
   private _Activatedroute:ActivatedRoute,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private modalService: BsModalService,
    private router: Router
  ) { }

  ngOnInit(): void {

    // this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    // this.router.onSameUrlNavigation='reload';
    this.estabelecimento = JSON.parse(localStorage.getItem('estabelecimento') ?? '{}');
    this.usuario = JSON.parse(localStorage.getItem('user') ?? '{}');
    //this.carregaMinhaAgenda(this.estabelecimento!.id);

    this._Activatedroute.params.subscribe(params => {
      this.id = params['id'];
     // console.log(this.id);
      this.carregaMinhaAgenda(this.estabelecimento!.id);
    });

  }

  carregaMinhaAgenda(estabelecimentoId: number) {
    this.spinner.show();
    this.agendaService.CarregaMinhaAgenda(estabelecimentoId)
      .subscribe(
        (_agendas: AgendaUsuario[]) => {

          this.Agendas = _agendas
         // console.log(this.Agendas);
        },
        () => {
          this.spinner.hide();
          this.toastr.error('Erro ao Carregar os Agendamentos', 'Erro!');
        }


      ).add(() => this.spinner.hide());


  }

  openModal(event: any, template: TemplateRef<any>, agendaId: number, dataAgendamento: Date, horaAgendada: Date): void {
    event.stopPropagation();
    this.agenda.id = agendaId;
    this.agenda.dataAgendamento = dataAgendamento;
    this.agenda.horaAgendada = horaAgendada;
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
  confirmar(): void {
    this.modalRef.hide();
    this.deletaAgendaUsuario(this.agenda.id);

  }
  negar(): void {
    this.modalRef.hide();
  }

  public deletaAgendaUsuario(agendaId: number) {
    this.spinner.show();
    this.agendaService.DeletaAgendaUsuario(agendaId)
      .subscribe(
        (resultado: any) => {

          if (resultado.retorno === 'Deletado') {
            this.toastr.success(
              'Agendamento cancelado',
              'Cancelado!'
            );
            this.carregaMinhaAgenda(this.estabelecimento!.id);
          }
        },
        (error: any) => {
          console.error(error);
          this.toastr.error(
            `Erro ao tentar cancelar seu agendamento!`,
            'Erro'
          );
        }
      ).add(() => this.spinner.hide());

  }

}

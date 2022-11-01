import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { getDay } from 'ngx-bootstrap/chronos';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { datepickerAnimation } from 'ngx-bootstrap/datepicker/datepicker-animations';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { combineLatest } from 'rxjs';
import { Agenda } from 'src/app/models/Agenda';
import { AgendaHorario } from 'src/app/models/AgendaHorario';
import { AgrupadoPorProfissionalHorario } from 'src/app/models/AgrupadoPorProfissionalHorario';
import { ControleDataAgenda } from 'src/app/models/ControleDataAgenda';
import { Estabelecimento } from 'src/app/models/Estabelecimento';
import { Horario } from 'src/app/models/Horario';
import { Usuario } from 'src/app/models/identity/Usuario';
import { Profissional } from 'src/app/models/Profissional';
import { ProfissionalHorario } from 'src/app/models/ProfissionalHorario';
import { Servico } from 'src/app/models/Servico';
import { ServicoProfissional } from 'src/app/models/ServicoProfissional';
import { AgendaService } from 'src/app/services/Agenda.service';
import { ProfissionalService } from 'src/app/services/Profissional.service';
import { ProfissionalHorarioService } from 'src/app/services/ProfissionalHorario.service';
import { ServicoService } from 'src/app/services/Servico.service';
import { ModalGravaAgendaComponent } from '../modal-grava-agenda/modal-grava-agenda.component';

@Component({
  selector: 'app-gerencia-agenda',
  templateUrl: './gerencia-agenda.component.html',
  styleUrls: ['./gerencia-agenda.component.scss']
})
export class GerenciaAgendaComponent implements OnInit {
  form!: FormGroup;
  public modalRef!: BsModalRef;
  public Servicos: Servico[] = [];
  public Profissionais: Profissional[] = [];
  public profissionalHorariosAgrupado: ProfissionalHorario[] = [];
  public AgrupadoPorProfissionalHorarios: AgrupadoPorProfissionalHorario[] = [];
  // public profissionalHorario = {} as ProfissionalHorario;
  // public profissionalHorariosAgrupado = {} as ProfissionalHorario;
  public Agenda = {} as Agenda;
  public Servico = {} as Servico;
  public imagemSelecionada = false;
  data?: Date;
  dataEntrada!: Date;
  dataSaida!: Date;
  Usuario = {} as Usuario;
  ControleDataAgenda = {} as ControleDataAgenda;



  public modoExibicao = "diario";
  public botaoSemanal = false;

  public estabelecimentoAtual = {} as Estabelecimento | null;


  get bsConfig(): any {
    return {
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY',
      showWeekNumbers: false,

    };
  }

  constructor(
    private profissionalHorarioServico: ProfissionalHorarioService,
    private profissionalServico: ProfissionalService,
    private servicoServico: ServicoService,
    private agendaService: AgendaService,
    private localeService: BsLocaleService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private modalService: BsModalService,
    private changeDetection: ChangeDetectorRef,
    private fb: FormBuilder,
    private router: Router,
  ) { this.localeService.use('pt-br'); };

  ngOnInit(): void {
    this.estabelecimentoAtual = JSON.parse(localStorage.getItem('estabelecimento') ?? '{}');
    this.Usuario = JSON.parse(localStorage.getItem('user') ?? '{}');


    this.carregaControleAgenda();



    this.validacao();

    this.form.controls["data"].setValue(new Date(this.ControleDataAgenda.dataSelecionada)); // new Date(this.dataEntrada.setDate(this.dataEntrada.getDate() + valor));
    this.Agenda.dataAgendamento = new Date(this.ControleDataAgenda.dataSelecionada);


    this.Agenda.userAtendenteId = this.Usuario.id;
    this.Agenda.estabelecimentoId = this.estabelecimentoAtual!.id;
    this.Agenda.servicoID = 0;
    this.Agenda.diaAgendado = getDay(this.Agenda.dataAgendamento);



    this.carregaProfissionais(this.estabelecimentoAtual!.id);
    this.carregaAgenda(this.ControleDataAgenda.profissionalId);

    this.agendaService.AtualizaDados.subscribe(response => {
      this.form.controls["data"].setValue(new Date(this.ControleDataAgenda.dataSelecionada)); // new Date(this.dataEntrada.setDate(this.dataEntrada.getDate() + valor));
      this.Agenda.dataAgendamento = new Date(this.ControleDataAgenda.dataSelecionada);
      this.carregaAgenda(this.ControleDataAgenda.profissionalId);
    });




  }

  private carregaControleAgenda() {

    if (localStorage.getItem('ControleDataAgenda'))
      this.ControleDataAgenda = JSON.parse(localStorage.getItem('ControleDataAgenda') ?? '{}');
    else {
      this.ControleDataAgenda.dataSelecionada = new Date();
      this.ControleDataAgenda.modoExibicao = "diario";
      this.ControleDataAgenda.profissionalId = 9999;
      this.defineControleAgenda(this.ControleDataAgenda);
    }
  }

  private defineControleAgenda(controleAgenda: ControleDataAgenda) {

    localStorage.setItem('ControleDataAgenda', JSON.stringify(controleAgenda));
  }
  private validacao() {
    this.form = this.fb.group({
      data: [''],
      servico: ['']

    });
  }

  atualizaConsultas(valorData: Date): void {
    //console.log(value);

    this.data = new Date(valorData.setDate(valorData.getDate()));
    this.Agenda.diaAgendado = getDay(this.data);
    this.Agenda.dataAgendamento = this.data;

    this.ControleDataAgenda.dataSelecionada = this.data;
    this.defineControleAgenda(this.ControleDataAgenda);
    if (this.Agenda.profissionalId) {
      this.carregaAgenda(this.Agenda.profissionalId);
    }



  }

  public carregaProfissionais(estabelecimentoAtual: number) {
    this.spinner.show();


    this.profissionalServico.CarregaProfissionais(estabelecimentoAtual)
      .subscribe(
        (profissionais: Profissional[]) => {
          this.Profissionais = profissionais;

          //console.log(this.Profissionais);
        },
        (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao Carregar os Profissionais', 'Erro!');
        }
      )
      .add(() => this.spinner.hide());

  }



  public carregaAgenda(profissionalId: number) {
    this.spinner.show();

    if (profissionalId != 9999)
      this.botaoSemanal = true;
    this.Agenda.profissionalId = profissionalId;
    this.ControleDataAgenda.profissionalId = profissionalId;

    this.defineControleAgenda(this.ControleDataAgenda);
    this.carregaControleAgenda();

    this.profissionalHorarioServico.CarregaProfissionalHorarios(this.Agenda, true, this.ControleDataAgenda.modoExibicao)
      .subscribe(
        (agrupadoPorProfissionalHorarios: AgrupadoPorProfissionalHorario[]) => {
          this.AgrupadoPorProfissionalHorarios = agrupadoPorProfissionalHorarios;
          //console.log(this.AgrupadoPorProfissionalHorarios);

        },
        (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao Carregar os Horários do Profissional', 'Erro!');
        }

      )
      .add(() => this.spinner.hide());


  }


  public mudaDia(valor: number) {
    this.dataEntrada = new Date(this.form.controls["data"].value);
    this.dataSaida = new Date(this.dataEntrada.setDate(this.dataEntrada.getDate() + valor));
    this.form.controls["data"].setValue(this.dataSaida);
    // this.atualizaConsultas(this.form.controls["data"].value);

  }
  public mudaSemana(valor: number) {
    this.dataEntrada = this.Agenda.dataAgendamento
    this.dataSaida = new Date(this.dataEntrada.setDate(this.dataEntrada.getDate() + valor));

    this.atualizaConsultas(this.dataSaida);

  }
  public mudaModoExibicao(modo: string) {

    this.modoExibicao = modo;
    this.ControleDataAgenda.modoExibicao = modo;
    this.defineControleAgenda(this.ControleDataAgenda);
    if (this.ControleDataAgenda.modoExibicao == 'diario') {
      this.botaoSemanal = false;
    }
    this.carregaAgenda(this.Agenda.profissionalId);
  }


  public carregaServicos() {
    this.spinner.show();

    this.servicoServico.CarregaServicos(this.Agenda.estabelecimentoId, this.Agenda.profissionalId).subscribe(

      (_servicos: Servico[]) => {
        this.Servicos = _servicos
        // console.log(this.Servicos);
      },
      (erro: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregar os Serviços', 'Erro!');

      },


    ).add(() => this.spinner.hide());
  }

  openModal(event: any, horarios: Horario, _profissionalHorario: ProfissionalHorario, dataAgendamento: Date): void {
    event.stopPropagation();
    if (horarios.agendaHorario == null) {
      this.Agenda.id = 0;
      this.Agenda.servicoID = 0;
      this.Agenda.observacao = "";
      this.Usuario.id = 0;
    }
    else {
      this.Agenda.id = horarios.agendaHorario.id;
      this.Agenda.servicoID = horarios.agendaHorario.servico.id;
      this.Agenda.observacao = horarios.agendaHorario.observacao;
      this.Usuario.id = horarios.agendaHorario.userCliente.id;
      this.Usuario.primeiroNome = horarios.agendaHorario.userCliente.primeiroNome;
      this.Usuario.ultimoNome = horarios.agendaHorario.userCliente.ultimoNome;

    }
    this.Agenda.diaAgendado = getDay(new Date(dataAgendamento));
    this.Agenda.horaAgendada = horarios.hora;
    this.Agenda.dataAgendamento = dataAgendamento;
    this.Agenda.profissionalId = horarios.profissionalId;

    const initialState: ModalOptions = {
      initialState: {
        Agenda: this.Agenda,
        Usuario: this.Usuario,
        ProfissionalHorario: _profissionalHorario,
      }
    }

    this.modalRef = this.modalService.show(ModalGravaAgendaComponent, initialState);

    if (this.modalRef?.onHide) {
      this.modalRef.onHide.subscribe(() => this.changeDetection.markForCheck());
      //this.modalRef.onHide.unsubscribe();


    }



  }



}


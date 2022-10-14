import { ChangeDetectorRef, Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { getDay } from 'ngx-bootstrap/chronos';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Agenda } from 'src/app/models/Agenda';
import { AgrupadoPorProfissionalHorario } from 'src/app/models/AgrupadoPorProfissionalHorario';
import { Estabelecimento } from 'src/app/models/Estabelecimento';
import { Usuario } from 'src/app/models/identity/Usuario';
import { ProfissionalHorario } from 'src/app/models/ProfissionalHorario';
import { Servico } from 'src/app/models/Servico';
import { ServicoProfissional } from 'src/app/models/ServicoProfissional';
import { AgendaService } from 'src/app/services/Agenda.service';
import { ProfissionalHorarioService } from 'src/app/services/ProfissionalHorario.service';
import { ServicoService } from 'src/app/services/Servico.service';
import { ServicoProfissionalService } from 'src/app/services/ServicoProfissional.service';

@Component({
  selector: 'app-marcar-agenda',
  templateUrl: './marcar-agenda.component.html',
  styleUrls: ['./marcar-agenda.component.scss']
})
export class MarcarAgendaComponent implements OnInit {
  form!: FormGroup;
  public modalRef!: BsModalRef;
  public Servicos: Servico[] = [];
  public ServicoProfissionais: ServicoProfissional[] = [];
  public ProfissionalHorarios: ProfissionalHorario[] = [];
  public AgrupadoPorProfissionalHorarios: AgrupadoPorProfissionalHorario[] = [];
  public Agenda = {} as Agenda;
  public Servico = {} as Servico;
  data?: Date;
  usuario = {} as Usuario;

  public estabelecimentoAtual = {} as Estabelecimento | null;
  public visibilidade = false;
  public visibilidadeHorarios = false;

  get bsConfig(): any {
    return {
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY',
      showWeekNumbers: false,
    };
  }


  constructor(private servicoServico: ServicoService,
    private servicoProfissionalServico: ServicoProfissionalService,
    private profissionalHorarioService: ProfissionalHorarioService,
    private agendaService: AgendaService,
    private localeService: BsLocaleService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private modalService: BsModalService,
    private changeDetection: ChangeDetectorRef,
    private fb: FormBuilder,
    private router: Router,
  ) { this.localeService.use('pt-br'); }

  ngOnInit(): void {

    this.estabelecimentoAtual = JSON.parse(localStorage.getItem('estabelecimento') ?? '{}');
    this.usuario = JSON.parse(localStorage.getItem('user') ?? '{}');
    this.validacao();

    this.Agenda.estabelecimentoId = this.estabelecimentoAtual!.id;
    this.carregaServicos(this.Agenda.estabelecimentoId);

    this.form.controls["data"].setValue(new Date());
    this.Agenda.dataAgendamento = new Date()

    this.visibilidade = false;
    this.visibilidadeHorarios = false;

    this.Agenda.userAtendenteId = this.usuario.id;
    this.Agenda.userClienteId = this.usuario.id;
    this.Agenda.statusAgendaID = 1; //Em Aberto





  }

  atualizaConsultas(valorData: Date): void {

    this.data = new Date(valorData.setDate(valorData.getDate()));
    this.Agenda.diaAgendado = getDay(this.data);
    this.Agenda.dataAgendamento = this.data;
    // console.log('valor de data');
    // console.log(this.Agenda.dataAgendamento);
    // console.log(this.Agenda.diaAgendado);
    if (this.Agenda.profissionalId) {
      this.carregaServicoProfissionais(null);
      this.carregaAgenda(this.Agenda.profissionalId);


    }



  }

  private validacao() {
    this.form = this.fb.group({
      data: [''],
      servico: [''],
      observacao: [''],

    });
  }

  public carregaServicos(estabelecimentoId: number) {
    this.spinner.show();
    console.log(estabelecimentoId);
    this.servicoServico.CarregaServicos(estabelecimentoId, 0).subscribe(

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

  public carregaServicoProfissionais(event: any) {

    this.Agenda.servicoID = this.form.controls["servico"].value;
    // ev.target.value
    if (event != null)
      this.Servico.descricao = event.target.options[event.target.options.selectedIndex].text;

    if (this.Agenda.servicoID) {
      this.spinner.show();

      this.servicoProfissionalServico.CarregaServicoProfissionais(this.Agenda.estabelecimentoId, this.Agenda.servicoID)
        .subscribe(
          (servicoProfissionais: ServicoProfissional[]) => {
            this.ServicoProfissionais = servicoProfissionais;
            // console.log(this.ServicoProfissionais);
          },
          (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao Carregar os Profissionais', 'Erro!');
          }


        ).add(() => this.spinner.hide());
      this.visibilidade = true;
      this.visibilidadeHorarios = false;
    }
    else {
      this.visibilidade = false;
      this.visibilidadeHorarios = false;
      this.ServicoProfissionais = [];
      this.form.controls["servico"].setValue('');


    }
  }

  public carregaAgenda(profissionalId: number) {
    this.spinner.show();
    this.visibilidadeHorarios = true;
    this.Agenda.profissionalId = profissionalId;
       //console.log(this.Agenda);
    this.profissionalHorarioService.CarregaProfissionalHorarios(this.Agenda, false, 'diario')
      .subscribe(
        (agrupadoPorProfissionalHorarios: AgrupadoPorProfissionalHorario[]) => {
          this.AgrupadoPorProfissionalHorarios = agrupadoPorProfissionalHorarios;
         // console.log(this.AgrupadoPorProfissionalHorarios);


        },
        (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao Carregar os Horários do Profissional', 'Erro!');
        }

      )
      .add(() => this.spinner.hide());



  }



  public geraAgenda() {
     this.spinner.show();
    //console.log(this.Agenda)
    this.agendaService.AdicionaAgenda(this.Agenda)
      .subscribe(
        (resultado: any) => {
          if (resultado.retorno === 'Adicionado') {
            this.toastr.success(
              'Agendamento marcado com sucesso.'
            );
           // this.carregaAgenda(this.Agenda.profissionalId);
          }
        },
        (error: any) => {
          console.error(error);
          this.toastr.error(
            `Erro ao tentar realizar a marcação da agenda nesse horário.`,
            'Erro'
          );

        }
      ).add(() => this.spinner.hide());


  }

  openModal(event: any, template: TemplateRef<any>, horaAgendada: Date, DataAgendamento: Date, profissionalId: number, primeiroNome: string, ultimoNome: string): void {
    event.stopPropagation();
    this.Agenda.diaAgendado = getDay(new Date(DataAgendamento));
    this.Agenda.horaAgendada = horaAgendada;
    this.Agenda.dataAgendamento = DataAgendamento;
    this.Agenda.profissionalId = profissionalId;
    this.usuario.primeiroNome = primeiroNome;
    this.usuario.ultimoNome = ultimoNome;

    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
    // if (this.modalRef?.onHide) {
    //   this.modalRef.onHide.subscribe(() => this.changeDetection.markForCheck());
    //   //this.modalRef.onHide?.unsubscribe();

    // }

  }


  confirmar(): void {

    this.Agenda.observacao = this.form.controls["observacao"].value;
    this.geraAgenda();
    // this.agendaService.AtualizaDados.subscribe(response => {
    //   this.carregaAgenda(this.Agenda.profissionalId);

    // });

    this.form.controls["observacao"].setValue('');
    // this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    // this.router.onSameUrlNavigation='reload';
    // this.router.navigate(['/pagina/minhaagenda']);
    this.modalRef.hide();
     this.router.navigate(['/pagina/minhaagenda']).then(() => {
       window.location.reload();
     });
   // this.router.navigate(['/pagina/minhaagenda']);


  }
  negar(): void {
    this.modalRef.hide();
  }
}

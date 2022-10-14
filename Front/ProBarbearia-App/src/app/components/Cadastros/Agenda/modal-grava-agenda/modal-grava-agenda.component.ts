import { ChangeDetectorRef, Component, OnInit, TemplateRef } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Agenda } from 'src/app/models/Agenda';
import { Usuario } from 'src/app/models/identity/Usuario';
import { UsuarioAgenda } from 'src/app/models/identity/UsuarioAgenda';
import { Profissional } from 'src/app/models/Profissional';
import { ProfissionalHorario } from 'src/app/models/ProfissionalHorario';
import { Servico } from 'src/app/models/Servico';
import { AgendaService } from 'src/app/services/Agenda.service';
import { ServicoService } from 'src/app/services/Servico.service';
import { UsuarioService } from 'src/app/services/usuario.service';
import { verificaNome } from './VerificaNome.validator';

@Component({
  selector: 'modal-content',
  templateUrl: './modal-grava-agenda.component.html',
  styleUrls: ['./modal-grava-agenda.component.scss']
})
export class ModalGravaAgendaComponent implements OnInit {
  form!: FormGroup;
  closeBtnName?: string;
  public Agenda = {} as Agenda;
  public Usuario = {} as Usuario;
  public ProfissionalHorario = {} as ProfissionalHorario;
  public usuarioNome?: string;
  public Servicos: Servico[] = [];
  public UsuariosAgenda: UsuarioAgenda[] = [];
  public validado = false as boolean;
  get f(): any { return this.form.controls; }

  constructor(public modalRef: BsModalRef,
    public modalRefCancelamento: BsModalRef,
    private modalService: BsModalService,
    private changeDetection: ChangeDetectorRef,
    private fb: FormBuilder,
    private servicoServico: ServicoService,
    private agendaService: AgendaService,
    private usuarioServico: UsuarioService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,

  ) { }

  ngOnInit(): void {

    this.modalRef.setClass('modal-lg');
    //    this.Agenda.userClienteId = 0;
    this.Agenda.statusAgendaID = 1;
    this.validacao();
    this.carregaServicos();
    if (this.Agenda.id) {
      this.usuarioNome = this.Usuario.primeiroNome + ' ' + this.Usuario.ultimoNome;
      this.form.controls["nome"].setValue(this.usuarioNome);
      this.form.controls["servico"].setValue(this.Agenda.servicoID);
      this.form.controls["observacao"].setValue(this.Agenda.observacao);

    }


  }

  private validacao() {
    this.form = this.fb.group({
      nome: ['', Validators.required],
      servico: ['', Validators.required],
      observacao: [''],
    });




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

  public pesquisarNome() {

    let nome = this.form.controls["nome"].value;

    if (nome != "") {
      this.spinner.show();
      this.usuarioServico.CarregaUsuariosPorNome(nome)
        .subscribe(
          (_usuarios: UsuarioAgenda[]) => {
            this.UsuariosAgenda = _usuarios


          },
          (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao Pesquisar Usuários', 'Erro!');
          }
        ).add(() => this.spinner.hide());

    }
    else
      this.UsuariosAgenda = [];

  }
  public selecionaUsuario(usuarioId: number, usuarioNome: string) {
    this.form.controls["nome"].setValue(usuarioNome);
    this.usuarioNome = usuarioNome;
    this.Agenda.userClienteId = usuarioId;

    if ((this.Agenda.servicoID) && (this.Agenda.userClienteId != 0))
      this.validado = true;

    this.UsuariosAgenda = [];


  }
  public selecionaServico(ev: any) {
    this.Agenda.servicoID = this.form.controls["servico"].value;
    if ((this.Agenda.servicoID) && (this.Agenda.userClienteId != 0))
      this.validado = true;

  }

  public geraAgenda() {
  // console.log(this.Agenda)
   this.spinner.show();

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

  confirmar(): void {

    this.Agenda.observacao = this.form.controls["observacao"].value;
    this.geraAgenda();
    this.form.controls["observacao"].setValue('');
    // this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    // this.router.onSameUrlNavigation='reload';
    // this.router.navigate(['/pagina/gerenciaagenda']);
    this.modalRef.hide();

    this.router.navigate(['/pagina/gerenciaagenda']).then(() => {
      window.location.reload();
    });

  }
  negar(): void {
    this.modalRef.hide();
  }

  openModal(event: any, template: TemplateRef<any>): void {
    event.stopPropagation();
    this.modalRefCancelamento = this.modalService.show(template, { class: 'modal-sm' });

  }
  confirmarCancelamento(): void {
    this.modalRefCancelamento.hide();
    this.deletaAgendaUsuario(this.Agenda.id);
    this.modalRef.hide();

    this.router.navigate(['/pagina/gerenciaagenda']).then(() => {
      window.location.reload();
    });

  }
  negarCancelamento(): void {
    this.modalRefCancelamento.hide();
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

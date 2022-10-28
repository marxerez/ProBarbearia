import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Estabelecimento } from 'src/app/models/Estabelecimento';

import { Usuario } from 'src/app/models/identity/Usuario';
import { UsuarioNaoProfissional } from 'src/app/models/identity/UsuarioNaoProfissional';
import { Profissional } from 'src/app/models/Profissional';
import { ProfissionalService } from 'src/app/services/Profissional.service';
import { UsuarioService } from 'src/app/services/usuario.service';
import { ValidaCampoSenha } from 'src/app/Validators/ValidaCampoSenha';

@Component({
  selector: 'app-perfil-detalhe',
  templateUrl: './perfil-detalhe.component.html',
  styleUrls: ['./perfil-detalhe.component.scss']
})
export class PerfilDetalheComponent implements OnInit {

  @Output() changeFormValue = new EventEmitter();
  @Output() setaTabServico: EventEmitter<boolean> = new EventEmitter();
  usuarioId!: number;
  profissional = {} as UsuarioNaoProfissional;
  public estabelecimentoAtual = {} as Estabelecimento | null;

  modoEditar = false;
  public funcaoProfissional = false;
  public funcaoCliente = false;

  usuarioAtualizado = {} as Usuario;
  form!: FormGroup;

  constructor(private fb: FormBuilder,
    public usuarioServico: UsuarioService,
    public profissionalServico: ProfissionalService,
    private activatedRouter: ActivatedRoute,
    private router: Router,
    private toaster: ToastrService,
    private spinner: NgxSpinnerService
  ) { }

  ngOnInit() {

    // console.log(this.router.url);

    this.estabelecimentoAtual = JSON.parse(localStorage.getItem('estabelecimento') ?? '{}');

    this.validacao();
    if (this.activatedRouter.snapshot.paramMap.get('id') == null)
      this.carregarUsuario();
    else {
      this.usuarioId = +this.activatedRouter.snapshot.paramMap.get('id')!;

      this.usuarioProfissionalId(this.usuarioId);
      this.profissional.userId = this.usuarioId;
      this.profissional.estabelecimentoId = this.estabelecimentoAtual!.id;

      this.profissionalServico.AtualizaDados.subscribe(response => {
        this.usuarioProfissionalId(this.usuarioId);

      });

    }

    if (this.router.url.includes('editar')) {
      this.form.disable();
      this.modoEditar = true;

    }
    this.verificaForm();

  }

  private verificaForm(): void {
    this.form.valueChanges
      .subscribe(() => this.changeFormValue.emit({ ...this.form.value }))


  }

  private carregarUsuario(): void {
    this.spinner.show();
    this.usuarioServico
      .usuarioLogado()
      .subscribe(
        (userRetorno: Usuario) => {

          this.form.patchValue(userRetorno);
          //  this.toaster.success('Usuário Carregado', 'Sucesso');
        },
        (error) => {
          console.error(error);
          this.toaster.error('Usuário não Carregado', 'Erro');
          this.router.navigate(['/pagina']);
        }
      )
      .add(() => this.spinner.hide());
  }

  private usuarioProfissionalId(usuarioId: number): void {
    this.spinner.show();
    this.usuarioServico
      .usuarioProfissionalId(usuarioId)
      .subscribe(
        (userRetorno: Usuario) => {

          this.form.patchValue(userRetorno);
          this.profissional.userName = userRetorno.userName;

          if (userRetorno.roles.some(role => role['name'] == 'Profissional'))
            this.funcaoProfissional = true;
          else
            this.funcaoProfissional = false;




        },
        (error) => {
          console.error(error);
          this.toaster.error('Profissional não Carregado', 'Erro');
          this.router.navigate(['/pagina']);
        }
      )
      .add(() => this.spinner.hide());
  }

  private validacao(): void {
    const formOptions: AbstractControlOptions = {
      validators: ValidaCampoSenha.ValidaCampo('password', 'confirmeSenha')
    };

    this.form = this.fb.group(
      {
        userName: [''],
        foto: [''],
        roles: [[]],
        primeiroNome: ['', Validators.required],
        ultimoNome: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        phoneNumber: ['', [Validators.required]],
        password: ['', [Validators.minLength(6), Validators.nullValidator]],
        confirmeSenha: ['', Validators.nullValidator],

      },
      formOptions
    );
  }

  // Conveniente para pegar um FormField apenas com a letra F
  get f(): any {
    return this.form.controls;
  }

  // onSubmit(): void {
  //   this.atualizarUsuario();
  // }

  public atualizarUsuario() {
    this.usuarioAtualizado = { ...this.form.value };
    this.spinner.show();


    this.usuarioServico
      .atualizaUsuario(this.usuarioAtualizado)
      .subscribe(
        () => this.toaster.success('Usuário atualizado!', 'Sucesso'),
        (error) => {
          this.toaster.error(error.error);
          console.error(error);
        }
      )
      .add(() => this.spinner.hide());
  }

  public resetForm(event: any): void {
    event.preventDefault();
    this.form.reset();
  }



}

import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Estabelecimento } from 'src/app/models/Estabelecimento';
import { Usuario } from 'src/app/models/identity/Usuario';
import { UsuarioNaoProfissional } from 'src/app/models/identity/UsuarioNaoProfissional';
import { ProfissionalService } from 'src/app/services/Profissional.service';
import { UsuarioService } from 'src/app/services/usuario.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  profissional = {} as UsuarioNaoProfissional;
  modoEditar = false;
  usuarioId!: number;
  public usuario = {} as Usuario;
  public file!: File;
  public imagemURL = './assets/img/perfil.png';
  // public imagemURL = './assets/img/usuarios/';
  public funcaoProfissional = false;
  public funcaoCliente = false;
  public estabelecimentoAtual = {} as Estabelecimento | null;

  constructor(private spinner: NgxSpinnerService,
    private toaster: ToastrService,
    private router: Router,
    public profissionalServico: ProfissionalService,
    private activatedRouter: ActivatedRoute,
    private usuarioServico: UsuarioService) { }

  ngOnInit() {
    this.estabelecimentoAtual = JSON.parse(localStorage.getItem('estabelecimento') ?? '{}');

    if (this.activatedRouter.snapshot.paramMap.get('id') != null) {

      this.usuarioId = +this.activatedRouter.snapshot.paramMap.get('id')!;

      this.usuarioProfissionalId(this.usuarioId);
      this.profissional.userId = this.usuarioId;
      this.profissional.estabelecimentoId = this.estabelecimentoAtual!.id;

      this.profissionalServico.AtualizaDados.subscribe(response => {
        this.usuarioProfissionalId(this.usuarioId);

      });

    }


    if (this.router.url.includes('editar')) {
      this.modoEditar = true;
    }
  }

  private usuarioProfissionalId(usuarioId: number): void {
    this.spinner.show();
    this.usuarioServico
      .usuarioProfissionalId(usuarioId)
      .subscribe(
        (userRetorno: Usuario) => {

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

  public setFormValue(usuarioAtualiza: Usuario): void {

    this.usuario = usuarioAtualiza;
    console.log(this.usuario);

    this.usuario.roles.forEach(role => {
      if (role['name'] == 'Profissional')
        this.funcaoProfissional = true;

      if (role['name'] == 'Cliente')
        this.funcaoCliente = true;

    });


    if (this.usuario.foto)
      this.imagemURL = './assets/img/usuarios/' + this.usuario.foto;       //environment.apiURL + `resources/perfil/${this.usuario.foto}`;
    else
      this.imagemURL = './assets/img/perfil.png';

  }
  public desativaTabs(ativa: boolean) {
    this.funcaoProfissional = ativa;

  }

  public ativarProfissional(event: any) {


    this.spinner.show();
    this.profissionalServico.AdicionaProfissional(this.profissional)
      .subscribe(
        (resultado: any) => {
          if (resultado.retorno === 'Adicionado') {
            this.toaster.success(
              'Profissional Ativado.'
            );
            // this.carregaAgenda(this.Agenda.profissionalId);
          }
        },
        (error: any) => {
          console.error(error);
          this.toaster.error(
            `Erro ao Ativar Profissional.`,
            'Erro'
          );

        }
      ).add(() => this.spinner.hide());

    this.desativaTabs(true);


  }

  public desativarProfissional(event: any) {


    this.spinner.show();
    this.profissionalServico.DeletaProfissional(this.profissional.estabelecimentoId, this.profissional.userId)
      .subscribe(
        (resultado: any) => {
          if (resultado.retorno === 'Deletado') {
            this.toaster.success(
              'Profissional Desativado.'
            );
            // this.carregaAgenda(this.Agenda.profissionalId);
          }
        },
        (error: any) => {
          console.error(error);
          this.toaster.error(
            `Erro ao Desativar Profissional.`,
            'Erro'
          );

        }
      ).add(() => this.spinner.hide());

    this.desativaTabs(false);


  }

  onFileChange(ev: any): void {
    const reader = new FileReader();

    reader.onload = (event: any) => this.imagemURL = event.target.result;

    this.file = (ev.srcElement || ev.target).files[0];

    reader.readAsDataURL(this.file);

    this.uploadImagem();
  }

  private uploadImagem(): void {
    // this.spinner.show();
    // this.accountService
    //   .postUpload(this.file)
    //   .subscribe(
    //     () => this.toastr.success('Imagem atualizada com Sucesso', 'Sucesso!'),
    //     (error: any) => {
    //       this.toastr.error('Erro ao fazer upload de imagem','Erro!');
    //       console.error(error);
    //     }
    //   ).add(() => this.spinner.hide());
  }

}

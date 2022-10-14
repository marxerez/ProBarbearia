import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Estabelecimento } from 'src/app/models/Estabelecimento';
import { Usuario } from 'src/app/models/identity/Usuario';
import { Servico } from 'src/app/models/Servico';
import { ServicoProfissionalEditar } from 'src/app/models/ServicoProfissionalEditar';
import { ServicoService } from 'src/app/services/Servico.service';
import { ServicoProfissionalService } from 'src/app/services/ServicoProfissional.service';

@Component({
  selector: 'app-servico-profissional',
  templateUrl: './servico-profissional.component.html',
  styleUrls: ['./servico-profissional.component.scss']
})
export class ServicoProfissionalComponent implements OnInit {
  usuarioId!: number;
  public estabelecimentoAtual = {} as Estabelecimento | null;
  usuario = {} as Usuario;
  public Servicos: Servico[] = [];
  public ServicosNaoAssociado: Servico[] = [];
  public ServicoProfissionalDeletar = {} as ServicoProfissionalEditar;
  public ServicoProfissionalAdicionar = {} as ServicoProfissionalEditar;
  public acessoViaPerfil = true;


  constructor(private servicoServico: ServicoService,
    private servicoProfissional: ServicoProfissionalService,
    private activatedRouter: ActivatedRoute,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
  ) { }



  ngOnInit(): void {

    this.estabelecimentoAtual = JSON.parse(localStorage.getItem('estabelecimento') ?? '{}');
    this.usuario = JSON.parse(localStorage.getItem('user') ?? '{}');
    if (this.activatedRouter.snapshot.paramMap.get('id') == null)
      this.carregaServicos(0, this.usuario.id);
    else {
      this.usuarioId = +this.activatedRouter.snapshot.paramMap.get('id')!;
      this.carregaServicos(this.estabelecimentoAtual!.id, this.usuarioId);
      this.carregaServicosNaoAssociado(this.estabelecimentoAtual!.id, this.usuarioId);
      this.acessoViaPerfil = false;


      this.servicoProfissional.AtualizaDados.subscribe(response => {
        this.carregaServicos(this.estabelecimentoAtual!.id, this.usuarioId);
        this.carregaServicosNaoAssociado(this.estabelecimentoAtual!.id, this.usuarioId);

      });

    }

  }

  public carregaServicosNaoAssociado(estabelecimentoId: number, profissionalId: number) {
    this.spinner.show();

    this.servicoServico.CarregaServicosNaoAssociado(estabelecimentoId, profissionalId).subscribe(

      (_servicos: Servico[]) => {
        this.ServicosNaoAssociado = _servicos
        // console.log(this.Servicos);

      },
      (erro: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregar os Serviços do Estabelecimento', 'Erro!');

      },


    ).add(() => this.spinner.hide());
  }

  public carregaServicos(estabelecimentoId: number, profissionalId: number) {
    this.spinner.show();

    this.servicoServico.CarregaServicos(estabelecimentoId, profissionalId).subscribe(

      (_servicos: Servico[]) => {
        this.Servicos = _servicos
        // console.log(this.Servicos);
      },
      (erro: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregar os Serviços do Profissional', 'Erro!');

      },


    ).add(() => this.spinner.hide());
  }


  deletaServico(servicoId: number): void {
    if (!this.acessoViaPerfil) {
      this.ServicoProfissionalDeletar.servicoId = servicoId;
      this.ServicoProfissionalDeletar.profissionalId = this.usuarioId;
      this.spinner.show();
      this.servicoProfissional.DeletaServicoProfissional(this.ServicoProfissionalDeletar.profissionalId, this.ServicoProfissionalDeletar.servicoId)
        .subscribe(
          (resultado: any) => {

            if (resultado.retorno === 'Deletado') {
              this.toastr.success(
                'Removido o serviço do profissional!',
                'Removido!'
              );
              // this.carregaMinhaAgenda(this.estabelecimento!.id);
            }
          },
          (error: any) => {
            console.error(error);
            this.toastr.error(
              `Erro ao tentar remover o serviço!`,
              'Erro'
            );
          }
        ).add(() => this.spinner.hide());

    }

  }

  adicionaServicoNaoAssociado(servicoId: number): void {
    if (!this.acessoViaPerfil) {
      this.ServicoProfissionalAdicionar.servicoId = servicoId;
      this.ServicoProfissionalAdicionar.profissionalId = this.usuarioId;
      this.spinner.show();

      this.servicoProfissional.AdicionaServicoProfissional(this.ServicoProfissionalAdicionar)
        .subscribe(
          (resultado: any) => {
            if (resultado.retorno === 'Adicionado') {
              this.toastr.success(
                'Serviço associado ao profissional com sucesso.'
              );

            }
          },
          (error: any) => {
            console.error(error);
            this.toastr.error(
              `Erro ao tentar associar o serviço ao profissional.`,
              'Erro'
            );

          }
        ).add(() => this.spinner.hide());



    }
  }


}

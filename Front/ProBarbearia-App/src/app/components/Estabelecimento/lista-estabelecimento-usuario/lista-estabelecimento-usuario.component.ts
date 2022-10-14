import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Cidade } from 'src/app/models/Cidade';
import { Estabelecimento } from 'src/app/models/Estabelecimento';
import { EstabelecimentoUsuario } from 'src/app/models/EstabelecimentoUsuario';
import { Estado } from 'src/app/models/Estado';
import { Usuario } from 'src/app/models/identity/Usuario';
import { CidadeService } from 'src/app/services/Cidade.service';
import { EstabelecimentoService } from 'src/app/services/Estabelecimento.service';
import { EstabelecimentoUsuarioService } from 'src/app/services/EstabelecimentoUsuario.service';
import { EstadoService } from 'src/app/services/Estado.service';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-lista-estabelecimento-usuario',
  templateUrl: './lista-estabelecimento-usuario.component.html',
  styleUrls: ['./lista-estabelecimento-usuario.component.scss']
})
export class ListaEstabelecimentoUsuarioComponent implements OnInit {

  form!: FormGroup;

  public  modalRef!:BsModalRef;
  estabelecimentoId=0;

  usuario = {} as Usuario;
  public Estabelecimentos: Estabelecimento[] = [];
  public EstabelecimentosNaoRegistrados: Estabelecimento[] = [];
  public Estados: Estado[] = [];
  public Cidades: Estado[] = [];
  public visibilidade = false;

  constructor(private estabelecimentoServico: EstabelecimentoService,
    private estabelecimentoUsuarioServico: EstabelecimentoUsuarioService,
    private estadoServico: EstadoService,
    private cidadeServico: CidadeService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private modalService: BsModalService,
    private router: Router,
    private fb: FormBuilder) { }

  ngOnInit(): void {

    //this.usuario = JSON.parse(localStorage.getItem('user') ?? '{}');
    this.validacao();
    this.visibilidade = false;

    this.carregaEstados();
    this.carregaEstabelecimentosPorUsuario();
  }


  private carregaEstabelecimentosPorUsuario(): void {
    this.spinner.show();
    this.estabelecimentoServico
      .CarregaEstabelecimentosPorUsuario()
      .subscribe(
        (_estabelecimentos: Estabelecimento[]) => { this.Estabelecimentos = _estabelecimentos },
        (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao Carregar os Estabelecimentos', 'Erro!');
        }
      ).add(() => this.spinner.hide());


  }

  private carregaEstados() {
    this.spinner.show();
    this.estadoServico.CarregaEstados().subscribe(

      (_estado: Estado[]) => {
        this.Estados = _estado

      },
      (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregar os Estados', 'Erro!');
      }
    ).add(() => this.spinner.hide());
  }

  public carregaCidades(ev: any) {
    let estado = this.form.controls["estado"].value;
    // ev.target.value
    if (estado) {

      this.spinner.show();
      this.cidadeServico.CarregaCidades(ev.target.value).subscribe(

        (_cidades: Cidade[]) => { this.Cidades = _cidades },
        (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao Carregar as Cidades', 'Erro!');
        }
      ).add(() => this.spinner.hide());
    }
    else {
      this.Cidades = [];
      this.form.controls["cidade"].setValue('');
      // console.log("cidade");
      // console.log(this.form.controls["cidade"].setValue(''));
    }
  }

  public defineEstabelecimentoAtual(estabelecimento: Estabelecimento) {
    this.estabelecimentoServico.defineEstabelecimentoAtual(estabelecimento);
    this.router.navigateByUrl('/pagina');

  }

  public adicionaEstabelecimentoUsuario(estabelecimentoId: number) {
    this.spinner.show();
    this.estabelecimentoUsuarioServico.AdicionaEstabelecimentoUsuario(estabelecimentoId)
      .subscribe(
        (resultado: any) => {

          if (resultado.retorno === 'Adicionado') {
            this.toastr.success(
              'Usuário associado ao estabelecimento com sucesso.',
              'Adicionado!'
            );
            this.carregaEstabelecimentosPorUsuario();
            this.pesquisar();
          }
        },
        (error: any) => {
          console.error(error);
          this.toastr.error(
            `Erro ao tentar associar o usuário ao estabelecimento`,
            'Erro'
          );
        }
      ).add(() => this.spinner.hide());

  }

  public deletaEstabelecimentoUsuario(estabelecimentoId: number) {
    this.spinner.show();
    this.estabelecimentoUsuarioServico.DeletaEstabelecimentoUsuario(estabelecimentoId)
      .subscribe(
        (resultado: any) => {

          if (resultado.retorno === 'Deletado') {
            this.toastr.success(
              'Removida a associação com o estabelecimento com sucesso.',
              'Removido!'
            );
            this.carregaEstabelecimentosPorUsuario();
            this.pesquisar();
          }
        },
        (error: any) => {
          console.error(error);
          this.toastr.error(
            `Erro ao tentar remover a associação do usuário com o estabelecimento`,
            'Erro'
          );
        }
      ).add(() => this.spinner.hide());

  }

  openModal(event: any, template: TemplateRef<any>, estabelecimentoId: number): void {
    event.stopPropagation();
    this.estabelecimentoId = estabelecimentoId;
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
  confirmar(): void {
    this.modalRef.hide();
    this.deletaEstabelecimentoUsuario(this.estabelecimentoId);

  }
  negar(): void {
    this.modalRef.hide();
  }

  private validacao() {
    this.form = this.fb.group({
      nome: [''],
      estado: [''],
      cidade: [''],


    });
  }

  public pesquisar(): void {
    let nome = this.form.controls["nome"].value;
    let estado = this.form.controls["estado"].value;
    let cidade = this.form.controls["cidade"].value;
    if (estado == "")
      estado = 0;
    if (cidade == "")
      cidade = 0;


    this.spinner.show();
    this.estabelecimentoServico.
      CarregaEstabelecimentoNaoRegistrado(nome, estado, cidade)
      .subscribe(
        (_estabelecimentosNaoRegistrados: Estabelecimento[]) => {
          this.EstabelecimentosNaoRegistrados = _estabelecimentosNaoRegistrados
          this.visibilidade = true;
        },
        (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao Pesquisar Novos Estabelecimentos', 'Erro!');
        }
      ).add(() => this.spinner.hide());





  }
}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Estabelecimento } from 'src/app/models/Estabelecimento';
import { Servico } from 'src/app/models/Servico';
import { ServicoService } from 'src/app/services/Servico.service';

@Component({
  selector: 'app-consulta-servico',
  templateUrl: './consulta-servico.component.html',
  styleUrls: ['./consulta-servico.component.scss']
})
export class ConsultaServicoComponent implements OnInit {
  form!: FormGroup;
  public Servico = {} as Servico;
  public estabelecimentoAtual = {} as Estabelecimento | null;
  public Servicos: Servico[] = [];
  get f(): any { return this.form.controls; }

  constructor(private fb: FormBuilder,
    private servicoServico: ServicoService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService) { }

  ngOnInit(): void {

    this.estabelecimentoAtual = JSON.parse(localStorage.getItem('estabelecimento') ?? '{}');

    this.validacao();

    this.carregaServicos();
  }


  private validacao() {
    this.form = this.fb.group({
      nome: [''],

    });
  }

  public carregaServicos() {

    this.spinner.show();

    this.servicoServico.CarregaServicos(this.estabelecimentoAtual!.id,0)
      .subscribe(
        (servicos: Servico[]) => {
          this.Servicos = servicos;

          //console.log(this.Servicos);
        },
        (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao Carregar os Servicos', 'Erro!');
        }
      )
      .add(() => this.spinner.hide());

  }

  public carregaServicosPorNome() {

    let nomeProfissional = this.form.controls["nome"].value;

    if (nomeProfissional != "") {
      this.spinner.show();

      this.servicoServico.CarregaServicos(this.estabelecimentoAtual!.id, nomeProfissional)
        .subscribe(
          (servicos: Servico[]) => {
            this.Servicos = servicos;

            //console.log(this.Servicos);
          },
          (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao Carregar os Servicos', 'Erro!');
          }
        )
        .add(() => this.spinner.hide());
    }
    else
      this.carregaServicos();
  }

  selecionaServico(id: number): void {
    this.router.navigate([`/pagina/perfil/${id}`]);
  }
  incluiServico(): void {
    this.router.navigate([`/pagina/profissionalEditar`]);
  }

}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Estabelecimento } from 'src/app/models/Estabelecimento';
import { Profissional } from 'src/app/models/Profissional';
import { ProfissionalService } from 'src/app/services/Profissional.service';

@Component({
  selector: 'app-consulta-profissional',
  templateUrl: './consulta-profissional.component.html',
  styleUrls: ['./consulta-profissional.component.scss']
})
export class ConsultaProfissionalComponent implements OnInit {
  form!: FormGroup;
  public Usuario = {} as Profissional;
  public estabelecimentoAtual = {} as Estabelecimento | null;
  public Profissionais: Profissional[] = [];
  get f(): any { return this.form.controls; }

  constructor(private fb: FormBuilder,
    private profissionalServico: ProfissionalService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,) { }

  ngOnInit(): void {

    this.estabelecimentoAtual = JSON.parse(localStorage.getItem('estabelecimento') ?? '{}');

    this.validacao();

    this.carregaProfissionais();
  }


  private validacao() {
    this.form = this.fb.group({
      nome: ['', Validators.required],

    });
  }

  public carregaProfissionais() {

    let nome = this.form.controls["nome"].value;

   // if (nome != "") {
      this.spinner.show();

      this.profissionalServico.CarregaProfissionais(this.estabelecimentoAtual!.id)
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
  //   else
  //     this.Profissionais = [];

  // }

  selecionaProfissional(id: number): void {
    this.router.navigate([`/pagina/perfil/${id}`]); 
  }
  incluiProfissional(): void {
    this.router.navigate([`/pagina/profissionalEditar`]);
  }

}

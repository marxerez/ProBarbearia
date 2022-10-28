import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Estabelecimento } from 'src/app/models/Estabelecimento';
import { UsuarioNaoProfissional } from 'src/app/models/identity/UsuarioNaoProfissional';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-edita-profissional',
  templateUrl: './edita-profissional.component.html',
  styleUrls: ['./edita-profissional.component.scss']
})
export class EditaProfissionalComponent implements OnInit {
  form!: FormGroup;
  public Usuario = {} as UsuarioNaoProfissional;
  public estabelecimentoAtual = {} as Estabelecimento | null;
  public Usuarios: UsuarioNaoProfissional[] = [];
  get f(): any { return this.form.controls; }

  constructor(private fb: FormBuilder,
    private usuarioServico: UsuarioService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.estabelecimentoAtual = JSON.parse(localStorage.getItem('estabelecimento') ?? '{}');

    this.validacao();

    this.carregaUsuariosNaoProfissionais();
  }
  private validacao() {
    this.form = this.fb.group({
      nome: [''],

    });
  }

  public carregaUsuariosNaoProfissionais() {

    let nomeUsuario = this.form.controls["nome"].value;


      this.spinner.show();

      this.usuarioServico.CarregaUsuariosNaoProfissionais(nomeUsuario,this.estabelecimentoAtual!.id)
        .subscribe(
          (usuarios: UsuarioNaoProfissional[]) => {
            this.Usuarios = usuarios;

            //console.log(this.Profissionais);
          },
          (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao Carregar os Profissionais', 'Erro!');
          }
        )
        .add(() => this.spinner.hide());

  }

  selecionaProfissional(id: number): void {
    this.router.navigate([`/pagina/perfil/${id}/editar`]);
  }

}

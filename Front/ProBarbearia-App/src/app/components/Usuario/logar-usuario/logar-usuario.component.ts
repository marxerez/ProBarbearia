
import { Component,  OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Estabelecimento } from 'src/app/models/Estabelecimento';
import { Usuario } from 'src/app/models/identity/Usuario';
import { UsuarioLogin } from 'src/app/models/identity/UsuarioLogin';
import { ThemeService } from 'src/app/services/Theme.service';
import { UsuarioService } from 'src/app/services/usuario.service';



@Component({
  selector: 'app-logar-usuario',
  templateUrl: './logar-usuario.component.html',
  styleUrls: ['./logar-usuario.component.scss']
})



export class LogarUsuarioComponent implements OnInit {
  user = {} as UsuarioLogin;
  usuarioLogado = {} as Usuario;

  form!: FormGroup;


  constructor(
    private fb: FormBuilder,
    private usuarioServico: UsuarioService,
    private router: Router,
    private toaster: ToastrService


  ) { }

  get f(): any { return this.form.controls; }

  ngOnInit(): void {
       this.validacao();
       localStorage.removeItem('user');
       localStorage.removeItem('estabelecimento');
       localStorage.removeItem('ControleDataAgenda');
  }

  public logar(): void {

    this.usuarioLogado = JSON.parse(localStorage.getItem('user') ?? '{}');
    this.user = { ...this.form.value };
    this.usuarioServico.logar(this.user).subscribe(
      () => {
        this.router.navigateByUrl('/estabelecimentos');
        this.toaster.success('Bem Vindo, '+ this.user.userName +'!', 'Sucesso');
      },
      (error: any) => {
        if (error.status == 401)
          this.toaster.error('usuário ou senha inválido');
        else this.toaster.error('Sistema Indisponível');
      }
    )


  }
  private validacao() {
    this.form = this.fb.group({
      userName: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],


    });

  }



}

import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Usuario } from 'src/app/models/identity/Usuario';
import { UsuarioService } from 'src/app/services/usuario.service';
import { ValidaCampoSenha } from 'src/app/Validators/ValidaCampoSenha';

@Component({
  selector: 'app-registrar-usuario',
  templateUrl: './registrar-usuario.component.html',
  styleUrls: ['./registrar-usuario.component.scss']
})
export class RegistrarUsuarioComponent implements OnInit {

  usuario = {} as Usuario;
  form!: FormGroup;

  constructor(private fb: FormBuilder,
              private usuarioServico: UsuarioService,
              private router: Router,
              private toaster: ToastrService

              ) { }



  get f(): any {return this.form.controls;}

  ngOnInit(): void {

    this.validacao();
  }

  private validacao(): void{

    const formOptions: AbstractControlOptions = {
      validators: ValidaCampoSenha.ValidaCampo('password', 'confirmeSenha')
    };

    this.form = this.fb.group({
      primeiroNome: ['', Validators.required],
      ultimoNome: ['', Validators.required],
      email: ['',
        [Validators.required, Validators.email]
      ],
      userName: ['', Validators.required],
      password: ['',
        [Validators.required, Validators.minLength(6)]
      ],
      confirmeSenha: ['', [Validators.required, Validators.minLength(6)]],
    }, formOptions);
  }

  registrar(): void{
    this.usuario = {...this.form.value};
    this.usuarioServico.registrar(this.usuario).subscribe(
      () => this.router.navigateByUrl('/estabelecimentos'),
      (error: any) => this.toaster.error(error.error)
    )

  }
}

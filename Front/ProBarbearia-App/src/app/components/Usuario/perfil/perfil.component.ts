import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Usuario } from 'src/app/models/identity/Usuario';
import { UsuarioService } from 'src/app/services/usuario.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  public usuario = {} as Usuario;
  public file!: File;
  public imagemURL='./assets/img/perfil.png';
 // public imagemURL = './assets/img/usuarios/';
  public funcaoProfissional = false;
  public funcaoCliente = false;

  constructor(private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private usuarioServico: UsuarioService) { }

  ngOnInit() {
  }

  public setFormValue(usuarioAtualiza: Usuario): void {
    this.usuario = usuarioAtualiza;


    this.usuario.roles.forEach(role => {
      if (role['name'] == 'Profissional')
        this.funcaoProfissional = true;

      if (role['name'] == 'Cliente')
        this.funcaoCliente = true;

    });

    console.log(this.usuario);
    if (this.usuario.foto)
      this.imagemURL = './assets/img/usuarios/' + this.usuario.foto;       //environment.apiURL + `resources/perfil/${this.usuario.foto}`;
    else
      this.imagemURL = './assets/img/perfil.png';

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

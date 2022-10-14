import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { TimepickerConfig } from 'ngx-bootstrap/timepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Usuario } from 'src/app/models/identity/Usuario';
import { ProfissionalHorarioEditar } from 'src/app/models/ProfissionalHorarioEditar';
import { ProfissionalHorarioService } from 'src/app/services/ProfissionalHorario.service';

export function getTimepickerConfig(): TimepickerConfig {
  return Object.assign(new TimepickerConfig(), {
    hourStep: 1,
    minuteStep: 5,
    showMeridian: false,
    readonlyInput: false,
    mousewheel: true,
    showMinutes: true,
    showSeconds: false,
    labelHours: 'Hours',
    labelMinutes: 'Minutes',
    labelSeconds: 'Seconds'
  });
}

@Component({
  selector: 'app-edita-horario-profissional',
  templateUrl: './edita-horario-profissional.component.html',
  styleUrls: ['./edita-horario-profissional.component.scss'],
  providers: [{ provide: TimepickerConfig, useFactory: getTimepickerConfig }]
})



export class EditaHorarioProfissionalComponent implements OnInit {
  usuarioId!: number;
  usuario = {} as Usuario;
  public ProfissionalHorariosEditar: ProfissionalHorarioEditar[] = [];
  public ProfissionalHorarioDeletar = {} as ProfissionalHorarioEditar;
  public ProfissionalHorarioAdicionar = {} as ProfissionalHorarioEditar;
  form!: FormGroup;
  public acessoViaPerfil = true;
  get f(): any { return this.form.controls; }

  constructor(
    private profissionalHorarioServico: ProfissionalHorarioService,
    private activatedRouter: ActivatedRoute,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private fb: FormBuilder) { }

  ngOnInit(): void {



    this.usuario = JSON.parse(localStorage.getItem('user') ?? '{}');
    if (this.activatedRouter.snapshot.paramMap.get('id') != null) {
      this.usuarioId = +this.activatedRouter.snapshot.paramMap.get('id')!;
      this.carregaProfissionalHorarios(this.usuarioId);
      this.acessoViaPerfil = false;

      this.profissionalHorarioServico.AtualizaDados.subscribe(response => {
        this.carregaProfissionalHorarios(this.usuarioId);

      });
    } else {
      this.carregaProfissionalHorarios(this.usuario.id);

    }

    this.validacao();

  }


  private validacao() {
    this.form = this.fb.group({
      diaSemana: ['', Validators.required],
      horaAbertura: ['', Validators.required],
      horaFechamento: ['', Validators.required],
      duracaoAtendimento: ['', Validators.required],

    });
  }
  public carregaProfissionalHorarios(profissionalId: number) {
    this.spinner.show();

    this.profissionalHorarioServico.CarregaProfissionalHorariosEditar(profissionalId).subscribe(

      (_profissionalHorarios: ProfissionalHorarioEditar[]) => {
        this.ProfissionalHorariosEditar = _profissionalHorarios

      },
      (erro: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregar os horários do Profissional', 'Erro!');

      },


    ).add(() => this.spinner.hide());
  }


  deletaProfissionalHorario(id: number): void {
    if (!this.acessoViaPerfil) {
      this.ProfissionalHorarioDeletar.id = id
      this.spinner.show();
      this.profissionalHorarioServico.DeletaProfissionalHorario(this.ProfissionalHorarioDeletar.id)
        .subscribe(
          (resultado: any) => {

            if (resultado.retorno === 'Deletado') {
              this.toastr.success(
                'Removido o horário do profissional!',
                'Removido!'
              );

            }
          },
          (error: any) => {
            console.error(error);
            this.toastr.error(
              `Erro ao tentar remover o horário do profissional!`,
              'Erro'
            );
          }
        ).add(() => this.spinner.hide());

    }

  }

  AdicionaProfissionalHorario(): void {

    this.ProfissionalHorarioAdicionar.diaSemana = this.form.controls["diaSemana"].value;
    this.ProfissionalHorarioAdicionar.horaAbertura = this.form.controls["horaAbertura"].value;
    this.ProfissionalHorarioAdicionar.horaFechamento = this.form.controls["horaFechamento"].value;
    this.ProfissionalHorarioAdicionar.duracaoAtendimento = this.form.controls["duracaoAtendimento"].value;
    this.ProfissionalHorarioAdicionar.profissionalId = this.usuarioId;
    //  console.log(this.ProfissionalHorarioAdicionar);
    this.spinner.show();

    this.profissionalHorarioServico.AdicionaProfissionalHorario(this.ProfissionalHorarioAdicionar)
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

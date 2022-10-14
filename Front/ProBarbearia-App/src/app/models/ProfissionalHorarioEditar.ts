import { Time } from "@angular/common";
import { Horario } from "./Horario";
import { Profissional } from "./Profissional";

export class ProfissionalHorarioEditar {
  id: number = 0;
  diaSemana: number = 0;
  horaAbertura!: Date;
  horaFechamento!: Date;
  duracaoAtendimento: number = 0;
  profissionalId: number = 0;

}

import { Time } from "@angular/common";
import { Horario } from "./Horario";
import { Profissional } from "./Profissional";

export class ProfissionalHorario {
  diaSemana: number = 0;
  dataAgendamento!: Date;
  profissional!: Profissional;
  horarios: Horario[] = [];
}

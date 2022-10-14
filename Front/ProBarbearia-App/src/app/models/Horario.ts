import { AgendaHorario } from "./AgendaHorario";
import { UsuarioAgenda } from "./identity/UsuarioAgenda";


export class Horario {

  agendaHorario!: AgendaHorario;
  profissionalId: number = 0;
  hora!: Date;
}

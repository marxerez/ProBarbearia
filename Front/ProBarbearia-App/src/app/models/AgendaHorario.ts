import { UsuarioAgenda } from "./identity/UsuarioAgenda";
import { Servico } from "./Servico";

export class AgendaHorario {

  id: number = 0;
  diaAgendado: number =0;
  observacao: string = "";
  dataAgendamento!: Date
  userCliente!: UsuarioAgenda;
  profissionalId: number = 0;
  horaAgendada!: Date;
  servico!: Servico;
}

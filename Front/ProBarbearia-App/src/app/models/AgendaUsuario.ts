import { Estabelecimento } from "./Estabelecimento";
import { Profissional } from "./Profissional";
import { Servico } from "./Servico";

export class AgendaUsuario {
  id: number = 0;
  horaAgendada!: Date
  dataAgendamento!: Date
  observacao: string=""
  profissional!: Profissional;
  estabelecimento!: Estabelecimento;
  servico!: Servico;


}

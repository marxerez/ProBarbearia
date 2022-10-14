export class Agenda {
  id: number = 0;
  diaAgendado: number = 0;
  horaAgendada!: Date;
  dataAgendamento!: Date;
  observacao: string="";
  ativo: Boolean =true;
  //Atendente
  userAtendenteId: number = 0;
  //Cliente
  userClienteId: number = 0;
  profissionalId: number = 9999;
  estabelecimentoId: number = 0;
  servicoID: number = 0;
  statusAgendaID: number = 0;
  //Em Aberto ,Agendado, Espera, Em Atendimento, Atendido, Cancelado, Atrasado


}

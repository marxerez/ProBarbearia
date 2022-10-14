using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProBarbearia.Application.Dtos.Agenda
{
    public class AgendaDto
    {
        public int Id { get; set; }

        public int DiaAgendado { get; set; }
        public DateTime HoraAgendada { get; set; }

        public DateTime DataAgendamento { get; set; }

        public string Observacao { get; set; }

        
        //Campo para bloquear um dia ou horário da agenda
        public Boolean Ativo { get; set; }
        
        //Atendente 
        public int UserAtendenteId{ get; set; }
        
        //Cliente
        public int UserClienteId { get; set; }
                
        public int ProfissionalId { get; set; }
        
        public int EstabelecimentoId { get; set; }
        
        public int ServicoID { get; set; }
        
        public int StatusAgendaID { get; set; }
        //Em Aberto ,Agendado, Espera, Em Atendimento, Atendido, Cancelado, Atrasado
       
       public Boolean gerenciaAgenda { get; set; }

       public string modoExibicao{ get; set;}
    }
}
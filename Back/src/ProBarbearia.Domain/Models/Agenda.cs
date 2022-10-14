using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Identity;

namespace ProBarbearia.Domain.Models
{
    public class Agenda
    {
        public int Id { get; set; }

        public int DiaAgendado { get; set; }
        public DateTime HoraAgendada { get; set; }

        public DateTime DataAgendamento { get; set; }

        public string Observacao { get; set; }

        
        //Campo para bloquear um dia ou horário da agenda
        public Boolean Ativo { get; set; }
        
        //Atendente 
        public int? UserAtendenteId{ get; set; }
        public User UserAtendente { get; set; }

        //Cliente
        public int? UserClienteId { get; set; }
        public User UserCliente { get; set; }
        
        public int? ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }

        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        public int ServicoID { get; set; }
        public Servico Servico { get; set; }
        public int StatusAgendaID { get; set; }
        //Em Aberto ,Agendado, Espera, Em Atendimento, Atendido, Cancelado, Atrasado
        public StatusAgenda StatusAgenda { get; set; }

        public Atendimento Atendimento { get; set; }
       

    }
}
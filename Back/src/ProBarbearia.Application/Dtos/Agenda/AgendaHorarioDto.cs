using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProBarbearia.Application.Dtos.Agenda
{
    public class AgendaHorarioDto
    {
        public int Id { get; set; }
        public int DiaAgendado { get; set; }
        public string Observacao { get; set; }
        public DateTime DataAgendamento { get; set; }
        public UsuarioAgendaDto UserCliente { get; set; } 
        public int ProfissionalId { get; set; }
        public DateTime HoraAgendada { get; set; }
        public ServicoDto Servico { get; set; }
      
       
    }
}
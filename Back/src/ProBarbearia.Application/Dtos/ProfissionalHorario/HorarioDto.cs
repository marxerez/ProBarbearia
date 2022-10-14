using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Application.Dtos.Agenda;

namespace ProBarbearia.Application.Dtos
{
    public class HorarioDto
    {
        public int DiaSemana { get; set; }
        public int ProfissionalId { get; set; }
        public DateTime Hora { get; set; }
        public AgendaHorarioDto AgendaHorario { get; set; }
    }
}
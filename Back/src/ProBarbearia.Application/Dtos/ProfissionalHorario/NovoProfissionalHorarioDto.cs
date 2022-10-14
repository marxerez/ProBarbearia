using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Identity;

namespace ProBarbearia.Application.Dtos
{
    public class NovoProfissionalHorarioDto
    {
      
        public int DiaSemana { get; set; }
        public DateTime DataAgendamento {get; set;}
        public ProfissionalRetornoDto profissional { get; set; }
        public List<HorarioDto> Horarios { get; set; }
        

    }
}

 
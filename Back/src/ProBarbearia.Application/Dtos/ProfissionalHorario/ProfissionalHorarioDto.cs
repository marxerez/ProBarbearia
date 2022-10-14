using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Identity;

namespace ProBarbearia.Application.Dtos
{
    public class ProfissionalHorarioDto
    {
       public int Id { get; set; }
       public int DiaSemana { get; set; }
        public DateTime HoraAbertura { get; set; }
        public DateTime HoraFechamento { get; set; }
        public int DuracaoAtendimento { get; set; }
        public int ProfissionalId { get; set; }
        public ProfissionalRetornoDto profissional { get; set; }
        public List<HorarioDto> Horarios { get; set; }
        

    }
}
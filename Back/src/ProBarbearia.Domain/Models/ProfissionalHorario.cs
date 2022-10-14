using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProBarbearia.Domain.Models
{
    public class ProfissionalHorario
    {
        public int Id { get; set; }
       public int DiaSemana { get; set; }
        public DateTime HoraAbertura { get; set; }
        public DateTime HoraFechamento { get; set; }
         public int DuracaoAtendimento { get; set; }
        public int? ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }
    }
}
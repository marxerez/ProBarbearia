using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProBarbearia.Domain.Models
{
    public class EstabelecimentoHorario
    {
        public int Id { get; set; }
        public int DiaSemana { get; set; }
        public DateTime HoraAbertura { get; set; }
        public DateTime HoraFechamento { get; set; }
        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
    }
}
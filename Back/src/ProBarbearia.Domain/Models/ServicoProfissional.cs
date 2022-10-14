using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProBarbearia.Domain.Models
{
    public class ServicoProfissional
    {
       public int Id { get; set; } 
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
        public int? ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }
    }
}
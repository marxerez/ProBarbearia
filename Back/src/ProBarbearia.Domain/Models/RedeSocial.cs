using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProBarbearia.Domain.Models
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
        public int? EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        public int? ProfissionalId { get; set; }
         public Profissional Profissional { get; set; }
    }
}
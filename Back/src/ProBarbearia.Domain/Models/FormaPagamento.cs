using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProBarbearia.Domain.Models
{
    public class FormaPagamento
    {
        public int Id { get; set; }
        public string decricao { get; set; }
        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }

        public IEnumerable<Atendimento> Atendimentos { get; set; }

        
    }
}
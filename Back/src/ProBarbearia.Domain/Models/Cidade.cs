using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProBarbearia.Domain.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        [StringLength(120)]
        public string Nome { get; set; }
        public int? Uf { get; set; }
        public int? Ibge { get; set; }
        
        public Estado Estado { get; set; }
        public IEnumerable<Estabelecimento> Estabelecimentos { get; set; }
    }
}
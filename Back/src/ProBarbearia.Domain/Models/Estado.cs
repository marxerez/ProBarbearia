using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProBarbearia.Domain.Models
{
    public class Estado
    {
        public int? Id { get; set; }
       [StringLength(75)]
        public string Nome { get; set; }
        [StringLength(2)]
        public string Uf { get; set; }
        public int? Ibge { get; set; }
        public int? Pais { get; set; }
        public string Ddd { get; set; }
         public IEnumerable<Cidade> Cidades { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProBarbearia.Domain.Models
{
    public class EstabelecimentoNaoRegistradoView
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string LogoMarcaImagem { get; set; }
        public int CidadeId { get; set; }
        
        public int Uf { get; set; }

    }
}
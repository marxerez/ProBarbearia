using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProBarbearia.Application.Dtos.Estabelecimento
{
    public class EstabelecimentoNaoRegistradoDto
    {


        public int Id { get; set; }
        public string Nome { get; set; }
        public string LogoMarcaImagem { get; set; }
        public int CidadeId { get; set; }
        
        public int Uf { get; set; }

       
    }
}
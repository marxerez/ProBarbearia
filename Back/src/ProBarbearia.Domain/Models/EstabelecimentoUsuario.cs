using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Identity;

namespace ProBarbearia.Domain.Models
{
    public class EstabelecimentoUsuario
    {
        public int EstabelecimentoID { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
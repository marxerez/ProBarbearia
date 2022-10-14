using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Identity;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Application.Dtos.EstabelecimentoUsuario
{
    public class EstabelecimentoUsuarioDto
    {
         public int EstabelecimentoID { get; set; }
        public int UserId { get; set; }
        

    }
}
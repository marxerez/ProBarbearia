using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProBarbearia.Application.Dtos
{
    public class UsuarioDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PrimeiroNome { get; set; }    
        public string UltimoNome { get; set; }
        public string Email { get; set; }

    }
}
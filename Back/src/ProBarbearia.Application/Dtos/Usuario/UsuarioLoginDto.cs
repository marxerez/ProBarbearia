using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProBarbearia.Application.Dtos
{
    public class UsuarioLoginDto
    {
        public string UserName  { get; set; }
        public string Password { get; set; }
    }
}
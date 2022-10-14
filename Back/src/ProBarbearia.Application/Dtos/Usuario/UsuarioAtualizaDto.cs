using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Identity;

namespace ProBarbearia.Application.Dtos
{
    public class UsuarioAtualizaDto
    {
         public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
       //public IEnumerable<UserRole> UserRoles { get; set; }
       public string Token { get; set; }
        public string Foto { get; set; }
    }
}
using System;
using System.Collections.Generic;

using ProBarbearia.Domain.Identity;


namespace ProBarbearia.Application.Dtos
{
    public class UsuarioRetornoDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public IEnumerable<RoleDto> Roles { get; set; }
        public string Token { get; set; }
        public string Foto { get; set; }
        public string PhoneNumber { get; set; }
    }
}
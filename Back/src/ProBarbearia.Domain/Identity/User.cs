using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Domain.Identity
{
    public class User: IdentityUser<int>
    {
        public string PrimeiroNome { get; set; }    
        public string UltimoNome { get; set; }
        public string Foto { get; set; }
        
         public IEnumerable<UserRole> UserRoles { get; set; }
         public Profissional Profissional { get; set; }
       
        public IEnumerable<Avaliacao> Avaliacoes { get; set; }

        public IEnumerable<EstabelecimentoUsuario> EstabelecimentosUsuarios { get; set; }

         public IEnumerable<Agenda> Agendas { get; set; }

    }
}
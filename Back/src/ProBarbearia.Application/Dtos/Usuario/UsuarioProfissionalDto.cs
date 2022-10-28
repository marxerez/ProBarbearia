using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProBarbearia.Application.Dtos
{
    public class UsuarioProfissionalDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PrimeiroNome { get; set; }    
        public string UltimoNome { get; set; }
        public string userName { get; set; }
        public string EstabelecimentoId { get; set; }
        
        

    }
}
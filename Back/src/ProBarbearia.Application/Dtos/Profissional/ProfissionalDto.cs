using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Identity;

namespace ProBarbearia.Application.Dtos
{
    public class ProfissionalDto
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Foto { get; set; }

    }
}
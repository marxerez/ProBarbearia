using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Identity;

namespace ProBarbearia.Application.Dtos
{
    public class ProfissionalRetornoDto
    {
        public int UserId { get; set; }
       
        public ProfissionalDto User { get; set; }
    }
}
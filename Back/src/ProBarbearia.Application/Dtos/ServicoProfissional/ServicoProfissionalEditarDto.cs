using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProBarbearia.Application.Dtos.ServicoProfissional
{
    public class ServicoProfissionalEditarDto
    {
        public int Id { get; set; } 
        public int ServicoId { get; set; }
        public int ProfissionalId { get; set; }
    }
}
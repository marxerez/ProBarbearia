using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Identity;

namespace ProBarbearia.Application.Dtos
{
    public class AgrupadoPorProfissionalHorarioDto
    {
      
        public ProfissionalRetornoDto profissional { get; set; }
        public List<NovoProfissionalHorarioDto> profissionalHorariosAgrupado { get; set; }
        

    }
}

 
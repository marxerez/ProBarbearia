using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProBarbearia.Application.Dtos;
using ProBarbearia.Application.Dtos.Estabelecimento;

namespace ProBarbearia.Application.Contratos
{
    public interface IProfissionalServico
    {
        Task<ProfissionalRetornoDto[]> CarregaProfissionais(int estabelecimentoId);
      
    }
}
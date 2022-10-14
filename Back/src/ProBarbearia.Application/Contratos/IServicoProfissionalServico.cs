using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProBarbearia.Application.Dtos;
using ProBarbearia.Application.Dtos.Estabelecimento;
using ProBarbearia.Application.Dtos.ServicoProfissional;

namespace ProBarbearia.Application.Contratos
{
    public interface IServicoProfissionalServico
    {
        
        Task<bool> AdicionaServicoProfissional(ServicoProfissionalEditarDto servicoProfissionalEditarDto);
        Task<bool> DeletaServicoProfissional(ServicoProfissionalEditarDto servicoProfissionalEditarDto);
        Task<ServicoProfissionalDto[]> CarregaServicoProfissionais(int estabelecimentoId, int servicoId);
        Task<ServicoProfissionalEditarDto> CarregaServicoProfissional(int profissionalId, int servicoId);
    }
}
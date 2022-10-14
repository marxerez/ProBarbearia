using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProBarbearia.Application.Dtos;
using ProBarbearia.Application.Dtos.Estabelecimento;

namespace ProBarbearia.Application.Contratos
{
    public interface IServicoServico
    {
        Task<ServicoDto[]> CarregaServicos(int estabelecimentoId,int profissionalId);
        Task<ServicoDto[]> CarregaServicosNaoAssociado(int estabelecimentoId,int profissionalId);
    }
}
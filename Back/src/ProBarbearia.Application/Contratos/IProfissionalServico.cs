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

        Task<bool> AdicionaProfissional(UsuarioProfissionalDto agendaDto);
        Task<bool> DeletaProfissional(UsuarioProfissionalDto agendaDto);
        Task<ProfissionalRetornoDto[]> CarregaProfissionais(int estabelecimentoId);
        Task<ProfissionalRetornoDto[]> CarregaProfissionaisPorNome(int estabelecimentoId, string nomeProfissional);

        Task<UsuarioProfissionalDto> CarregaProfissionalPorId(int estabelecimentoId,int usuarioId);


    }
}
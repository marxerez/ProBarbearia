using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProBarbearia.Application.Dtos;
using ProBarbearia.Application.Dtos.Agenda;
using ProBarbearia.Application.Dtos.Estabelecimento;

namespace ProBarbearia.Application.Contratos
{
    public interface IProfissionalHorarioServico
    {
        Task<bool> AdicionaProfissionalHorario(ProfissionalHorarioEditarDto profissionalHorarioEditarDto);
        Task<bool> DeletaProfissionalHorario(ProfissionalHorarioEditarDto profissionalHorarioEditarDto);
        Task<AgrupadoPorProfissionalHorarioDto[]> CarregaProfissionalHorarios(AgendaDto agendaDto, AgendaHorarioDto[] agendaHorarioDto, Boolean gerenciaAgenda, string modoExibicao);

        Task<ProfissionalHorarioEditarDto[]> CarregaProfissionalHorariosEditar(int profissionalId);

        Task<ProfissionalHorarioEditarDto> CarregaProfissionalHorarioPorId(int id);




    }
}
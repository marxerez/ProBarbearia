using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Application.Dtos.Agenda;

namespace ProBarbearia.Application.Contratos
{
    public interface IAgendaServico
    {

        Task<bool> AdicionaAgenda(AgendaDto agendaDto);
        Task<bool> DeletaAgenda(AgendaDto agendaDto);
        Task<AgendaDto> CarregaAgendaUsuario(int agendaId);
        Task<AgendaRetornoDto[]> CarregaAgenda(int usuarioId, int estabelecimentoId);
        Task<AgendaHorarioDto[]> CarregaAgendaHorario(AgendaDto agendaDto, string modoExibicao);
       
      
       
    }
}
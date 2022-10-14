using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Models;


namespace ProBarbearia.Persistence.Contratos
{
    public interface IAgendaPersistencia: IGeralPersistencia
    {
        Task<Agenda> CarregaAgendaUsuario(int agendaId);
        Task<Agenda[]> CarregaAgenda(int usuarioId, int estabelecimentoId);
        Task<Agenda[]> CarregaAgendaHorario(Agenda agendaParametros, string modoExibicao);
        
        

    }
}
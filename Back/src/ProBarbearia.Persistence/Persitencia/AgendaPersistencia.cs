
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProBarbearia.Persistence.Contextos;
using ProBarbearia.Persistence.Contratos;
using ProBarbearia.Domain.Models;
using System;

namespace ProBarbearia.Persistence
{
    public class AgendaPersistencia : GeralPersistencia, IAgendaPersistencia
    {
        private readonly ProBarbeariaContext _contexto;

        public AgendaPersistencia(ProBarbeariaContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }


        public async Task<Agenda> CarregaAgendaUsuario(int agendaId)
        {

            IQueryable<Agenda> query = _contexto.Agenda.AsNoTracking();


            query = query.Where(x => x.Id == agendaId);


            return await query.FirstOrDefaultAsync();

        }


        public async Task<Agenda[]> CarregaAgenda(int usuarioId, int estabelecimentoId)
        {

            IQueryable<Agenda> query = _contexto.Agenda
            .Include(x => x.Estabelecimento)
            .Include(x => x.Servico)
            .Include(x => x.Profissional)
            .ThenInclude(x => x.User);


            query = query.AsNoTracking();
            query = query.Where(x => x.EstabelecimentoId == estabelecimentoId);
            query = query.Where(x => x.UserClienteId == usuarioId);
            query = query.Where(x => x.StatusAgendaID == 1); //Agenda com status Em Aberto
            query = query.OrderBy(x => x.DataAgendamento).ThenBy(x => x.HoraAgendada);


            return await query.ToArrayAsync();

        }

        public async Task<Agenda[]> CarregaAgendaHorario(Agenda agendaParametros, string modoExibicao)
        {
            int diaSemana = (int)agendaParametros.DataAgendamento.DayOfWeek;
            DateTime dtInicial = agendaParametros.DataAgendamento.AddDays(-diaSemana);
            DateTime dtFinal = agendaParametros.DataAgendamento.AddDays(7 - diaSemana - 1);


            IQueryable<Agenda> query = _contexto.Agenda
            .Include(x => x.Servico)
            .Include(x => x.UserCliente);

            query = query.AsNoTracking();
            if (agendaParametros.ProfissionalId != 9999)
                query = query.Where(x => x.ProfissionalId == agendaParametros.ProfissionalId);

            if (modoExibicao == "semanal")
            {
                query = query.Where(x => x.DataAgendamento.Date >= dtInicial.Date && x.DataAgendamento.Date <= dtFinal.Date);
                query = query.Where(x => x.EstabelecimentoId == agendaParametros.EstabelecimentoId);
                query = query.OrderBy(x => x.ProfissionalId).ThenBy(x => x.DiaAgendado).ThenBy(x => x.HoraAgendada);
                
            }
            else
            {
                query = query.Where(x => x.DiaAgendado == agendaParametros.DiaAgendado);
                query = query.Where(x => x.DataAgendamento.Date == agendaParametros.DataAgendamento.Date);
                query = query.OrderBy(x => x.ProfissionalId).ThenBy(x => x.DiaAgendado).ThenBy(x => x.HoraAgendada);
            }

            return await query.ToArrayAsync();

        }



    }
}
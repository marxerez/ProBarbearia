
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProBarbearia.Persistence.Contextos;
using ProBarbearia.Persistence.Contratos;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Persistence
{
    public class ProfissionalHorarioPersistencia : GeralPersistencia, IProfissionalHorarioPersistencia
    {
        private readonly ProBarbeariaContext _contexto;

        public ProfissionalHorarioPersistencia(ProBarbeariaContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<ProfissionalHorario[]> CarregaProfissionalHorarios(Agenda agenda, bool gerenciaAgenda, string modoExibicao)
        {

            IQueryable<ProfissionalHorario> query = _contexto.ProfissionalHorario
                    .Include(x => x.Profissional)
                    .ThenInclude(x => x.User);


            query = query.AsNoTracking();
            if (agenda.ProfissionalId != 9999)
                query = query.Where(x => x.ProfissionalId == agenda.ProfissionalId);



            if (!gerenciaAgenda)
                query = query.Where(x => x.Profissional.ServicosProfissionais.Any(x => x.ServicoId == agenda.ServicoID));
            query = query.Where(x => x.Profissional.EstabelecimentoId == agenda.EstabelecimentoId);

            if (modoExibicao == "semanal")
            {
                query = query.Where(x => x.DiaSemana >= 1 && x.DiaSemana <= 7);
                query = query.OrderBy(x => x.ProfissionalId).ThenBy(x => x.DiaSemana).ThenBy(x => x.HoraAbertura);

            }
            else
            {
                query = query.Where(x => x.DiaSemana == agenda.DiaAgendado);
                query = query.OrderBy(x => x.ProfissionalId).ThenBy(x => x.DiaSemana).ThenBy(x => x.HoraAbertura);
            }

            return await query.ToArrayAsync();

        }




        public async Task<ProfissionalHorario[]> CarregaProfissionalHorariosEditar(int profissionalId)
        {

            IQueryable<ProfissionalHorario> query = _contexto.ProfissionalHorario;
                    
            query = query.AsNoTracking();
            query = query.Where(x => x.ProfissionalId == profissionalId);
            query = query.OrderBy(x => x.DiaSemana).ThenBy(x => x.HoraAbertura);
          
            return await query.ToArrayAsync();

        }


        public async Task<ProfissionalHorario> CarregaProfissionalHorarioPorId(int id)
        {


            IQueryable<ProfissionalHorario> query = _contexto.ProfissionalHorario.AsNoTracking();
            query = query.Where(x => x.Id == id);

            return await query.FirstOrDefaultAsync();





        }
    }
}
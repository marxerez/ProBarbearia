
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProBarbearia.Persistence.Contextos;
using ProBarbearia.Persistence.Contratos;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Persistence
{
    public class ProfissionalPersistencia : GeralPersistencia, IProfissionalPersistencia
    {
        private readonly ProBarbeariaContext _contexto;

        public ProfissionalPersistencia(ProBarbeariaContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<Profissional[]> CarregaProfissionais(int estabelecimentoId)
        {


            IQueryable<Profissional> query = _contexto.Profissional
            .Include(x => x.User);

            query = query.AsNoTracking();
            query = query.Where(x => x.EstabelecimentoId == estabelecimentoId);
            query = query.OrderBy(x => x.User.PrimeiroNome);
         
            return await query.ToArrayAsync();


        }
        public async Task<Profissional[]> CarregaProfissionaisPorNome(int estabelecimentoId, string nomeProfissional)
        {


            IQueryable<Profissional> query = _contexto.Profissional
            .Include(x => x.User);

            query = query.AsNoTracking();
            query = query.Where(x => x.EstabelecimentoId == estabelecimentoId);
            query = query.Where(x => x.User.PrimeiroNome.Contains(nomeProfissional) || x.User.UltimoNome.Contains(nomeProfissional));
            query = query.OrderBy(x => x.User.PrimeiroNome);
         
            return await query.ToArrayAsync();


        }

  
    public async Task<Profissional> CarregaProfissionalPorId(int estabelecimentoId,int usuarioId)
        {


            IQueryable<Profissional> query = _contexto.Profissional.AsNoTracking();
            query = query.Where(x => x.UserId == usuarioId && x.EstabelecimentoId == estabelecimentoId);
            
            return await query.FirstOrDefaultAsync();


          


        }


    }
}
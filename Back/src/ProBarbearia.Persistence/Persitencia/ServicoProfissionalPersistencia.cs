
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProBarbearia.Persistence.Contextos;
using ProBarbearia.Persistence.Contratos;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Persistence
{
    public class ServicoProfissionalPersistencia : GeralPersistencia, IServicoProfissionalPersistencia
    {
        private readonly ProBarbeariaContext _contexto;

        public ServicoProfissionalPersistencia(ProBarbeariaContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }



        public async Task<ServicoProfissional[]> CarregaServicoProfissionais(int estabelecimentoId, int servicoId)
        {

            IQueryable<ServicoProfissional> query = _contexto.ServicoProfissonal
            .Include(x => x.Profissional)
            .ThenInclude(x => x.User);

            query = query.AsNoTracking();
            query = query.Where(x => x.ServicoId == servicoId);
            query = query.Where(x => x.Profissional.EstabelecimentoId == estabelecimentoId);
            query = query.OrderBy(x => x.Profissional.User.PrimeiroNome);
              
            return await query.ToArrayAsync();


        }
        public async Task<ServicoProfissional> CarregaServicoProfissional(int profissionalId, int servicoId)
        {


            IQueryable<ServicoProfissional> query = _contexto.ServicoProfissonal.AsNoTracking();
            query = query.Where(x => x.ProfissionalId == profissionalId && x.ServicoId == servicoId);
            
            return await query.FirstOrDefaultAsync();


          


        }


    }
}

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


    }
}
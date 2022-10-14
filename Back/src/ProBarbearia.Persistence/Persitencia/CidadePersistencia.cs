
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProBarbearia.Persistence.Contextos;
using ProBarbearia.Persistence.Contratos;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Persistence
{
    public class CidadePersistencia : GeralPersistencia, ICidadePersistencia
    {
        private readonly ProBarbeariaContext _contexto;

        public CidadePersistencia(ProBarbeariaContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<Cidade[]> CarregaCidades(int estadoId)
        {

            IQueryable<Cidade> query = _contexto.Cidade;
                                                
                        query = query.AsNoTracking();
                         query = query.Where(x => x.Uf == estadoId);
                         query = query.OrderBy( x => x.Nome);
                        

            return await query.ToArrayAsync();

        }


    }
}
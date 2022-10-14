
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProBarbearia.Persistence.Contextos;
using ProBarbearia.Persistence.Contratos;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Persistence
{
    public class EstadoPersistencia : GeralPersistencia, IEstadoPersistencia
    {
        private readonly ProBarbeariaContext _contexto;

        public EstadoPersistencia(ProBarbeariaContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<Estado[]> CarregaEstados()
        {

            IQueryable<Estado> query = _contexto.Estado;
                                                
                        query = query.AsNoTracking();
                        query = query.OrderBy( x => x.Nome);
                        

            return await query.ToArrayAsync();

        }


    }
}
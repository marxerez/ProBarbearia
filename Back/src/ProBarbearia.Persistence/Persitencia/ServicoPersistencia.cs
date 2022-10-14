
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProBarbearia.Persistence.Contextos;
using ProBarbearia.Persistence.Contratos;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Persistence
{
    public class ServicoPersistencia : GeralPersistencia, IServicoPersistencia
    {
        private readonly ProBarbeariaContext _contexto;

        public ServicoPersistencia(ProBarbeariaContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<Servico[]> CarregaServicos(int estabelecimentoId, int profissionalId)
        {

            IQueryable<Servico> query = _contexto.Servico;

            query = query.AsNoTracking();
            if (estabelecimentoId != 0)
                query = query.Where(x => x.EstabelecimentoID == estabelecimentoId);
            if (profissionalId != 0)
                query = query.Where(x => x.ServicosProfissionais.Any(x => x.ProfissionalId == profissionalId));

            query = query.OrderBy(x => x.Descricao);


            return await query.ToArrayAsync();
        }

 public async Task<Servico[]> CarregaServicosNaoAssociado(int estabelecimentoId, int profissionalId)
        {

            IQueryable<Servico> query = _contexto.Servico;

            query = query.AsNoTracking();
            query = query.Where(x => x.EstabelecimentoID == estabelecimentoId);
            if (profissionalId != 0)
                query = query.Where(x =>  !x.ServicosProfissionais.Any(x => x.ProfissionalId == profissionalId));

            query = query.OrderBy(x => x.Descricao);


            return await query.ToArrayAsync();
        }

    }
}
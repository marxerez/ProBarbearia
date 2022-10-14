using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using ProBarbearia.Persistence.Contextos;
using ProBarbearia.Persistence.Contratos;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Persistence
{
    public class EstabelecimentoPersistencia : GeralPersistencia, IEstabelecimentoPersistencia
    {
        private readonly ProBarbeariaContext _contexto;

        public EstabelecimentoPersistencia(ProBarbeariaContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<Estabelecimento[]> CarregaEstabelecimentosPorUsuario(int usuarioId)
        {

            IQueryable<Estabelecimento> query = _contexto.Estabelecimento
                        .Include(x => x.EstabelecimentosUsuarios)
                        .ThenInclude(x => x.User);

            query = query.AsNoTracking();
            query = query.Where(x => x.EstabelecimentosUsuarios.Any(x => x.UserId == usuarioId));

            return await query.ToArrayAsync();

        }

        public async Task<Estabelecimento[]> CarregaEstabelecimentoNaoRegistrado(int usuarioId, string nome, int estadoId, int cidadeId)
        {


            IQueryable<Estabelecimento> query = _contexto.Estabelecimento
                        .Include(x => x.Cidade)
                        .Include(x => x.EstabelecimentosUsuarios)
                        .ThenInclude(x => x.User);

            query = query.AsNoTracking();
            query = query.Where(x => !x.EstabelecimentosUsuarios.Any(x => x.UserId == usuarioId));

            if (!string.IsNullOrEmpty(nome))
                query = query.Where(x => x.Nome.ToLower().Contains(nome.ToLower()));
            if (estadoId > 0)
                query = query.Where(x => x.Cidade.Uf == estadoId);
            if (cidadeId > 0)
                query = query.Where(x => x.CidadeId == cidadeId);






            return await query.ToArrayAsync();

        }


    }
}
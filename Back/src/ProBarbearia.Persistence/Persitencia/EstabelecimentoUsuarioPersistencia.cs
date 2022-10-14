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
    public class EstabelecimentoUsuarioPersistencia : GeralPersistencia, IEstabelecimentoUsuarioPersistencia
    {
        private readonly ProBarbeariaContext _contexto;

        public EstabelecimentoUsuarioPersistencia(ProBarbeariaContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<EstabelecimentoUsuario> CarregaEstabelecimentoUsuario(int estabelecimentoId, int usuarioId)
        {

            IQueryable<EstabelecimentoUsuario> query = _contexto.EstabelecimentoUsuario.AsNoTracking();


            query = query.Where(x => x.UserId == usuarioId && x.EstabelecimentoID == estabelecimentoId);
                        

            return await query.FirstOrDefaultAsync();

        }




    }
}
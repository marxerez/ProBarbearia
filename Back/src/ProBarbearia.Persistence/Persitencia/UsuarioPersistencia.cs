using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using ProBarbearia.Persistence.Contextos;
using ProBarbearia.Persistence.Contratos;

namespace ProBarbearia.Persistence
{
    public class UsuarioPersistencia : GeralPersistencia, IUsuarioPersistencia
    {
        private readonly ProBarbeariaContext _contexto;

        public UsuarioPersistencia(ProBarbeariaContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }


        public async Task<User> CarregaUsuarioPorId(int usuarioId)
        {
             var retorno = await _contexto.Users
                                .Include(x => x.UserRoles)
                                .ThenInclude(x => x.Role)
                                .SingleOrDefaultAsync(usuario => usuario.Id == usuarioId);

            return retorno;
        }

        public async Task<User> CarregaUsuarioPorNome(string nomeUsuario)
        {
            var retorno = await _contexto.Users
                                .Include(x => x.UserRoles)
                                .ThenInclude(x => x.Role)
                                .SingleOrDefaultAsync(usuario => usuario.UserName == nomeUsuario.ToLower());

            return retorno;
            //await _contexto.Users.SingleOrDefaultAsync(usuario => usuario.UserName== nomeUsuario.ToLower());
        }

        public async Task<User[]> CarregaUsuariosPorNome(string nomeUsuario)
        {
            IQueryable<User> query = _contexto.Users
            .Where(x => x.PrimeiroNome.Contains(nomeUsuario) || x.UltimoNome.Contains(nomeUsuario))
            .OrderBy(x => x.PrimeiroNome).ThenBy(x => x.UltimoNome);

            return await query.ToArrayAsync();

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Identity;

namespace ProBarbearia.Persistence.Contratos
{
    public interface IUsuarioPersistencia: IGeralPersistencia
    {
       Task<User[]> CarregaUsuariosPorNome(string nomeUsuario);
        
        Task<User> CarregaUsuarioPorId(int usuarioId);
        Task<User> CarregaUsuarioPorNome(string nomeUsuario);

    }
}
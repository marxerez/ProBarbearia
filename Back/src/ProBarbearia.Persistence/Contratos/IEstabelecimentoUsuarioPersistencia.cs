using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Persistence.Contratos
{
    public interface IEstabelecimentoUsuarioPersistencia: IGeralPersistencia
    {
        Task<EstabelecimentoUsuario> CarregaEstabelecimentoUsuario(int estabelecimentoId,int usuarioId);
       

    }
}
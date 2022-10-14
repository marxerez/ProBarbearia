using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Persistence.Contratos
{
    public interface ICidadePersistencia: IGeralPersistencia
    {
        Task<Cidade[]> CarregaCidades(int estadoId);
        

    }
}
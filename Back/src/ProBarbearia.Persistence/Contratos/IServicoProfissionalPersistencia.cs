using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Persistence.Contratos
{
    public interface IServicoProfissionalPersistencia : IGeralPersistencia
    {
        Task<ServicoProfissional[]> CarregaServicoProfissionais(int estabelecimentoId, int servicoId);
        Task<ServicoProfissional> CarregaServicoProfissional(int profissionalId, int servicoId);


    }
}
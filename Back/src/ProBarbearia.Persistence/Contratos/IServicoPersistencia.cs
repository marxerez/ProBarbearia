using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Persistence.Contratos
{
    public interface IServicoPersistencia: IGeralPersistencia
    {
        Task<Servico[]> CarregaServicos(int estabelecimentoId,int profissionalId);
        Task<Servico[]> CarregaServicosNaoAssociado(int estabelecimentoId,int profissionalId);
        

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Persistence.Contratos
{
    public interface IEstabelecimentoPersistencia: IGeralPersistencia
    {
        Task<Estabelecimento[]> CarregaEstabelecimentosPorUsuario(int usuarioId);
        Task<Estabelecimento[]> CarregaEstabelecimentoNaoRegistrado(int usuarioId, string nome, int estadoId, int cidadeId);
        
        

    }
}
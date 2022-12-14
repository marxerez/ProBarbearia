using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Persistence.Contratos
{
    public interface IProfissionalPersistencia: IGeralPersistencia
    {
        Task<Profissional[]> CarregaProfissionais(int estabelecimentoId);
        Task<Profissional[]> CarregaProfissionaisPorNome(int estabelecimentoId, string nomeProfissional);
        Task<Profissional> CarregaProfissionalPorId(int estabelecimentoId,int usuarioId);
       
        

    }
}
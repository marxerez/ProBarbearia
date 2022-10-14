using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProBarbearia.Persistence.Contratos
{
    public interface IGeralPersistencia
    {
        void Adiciona<T>(T entidade) where T: class;
        void Atualiza<T>(T entidade) where T: class;
        void Deleta<T>(T entidade) where T: class;
        void DeletaVarios<T>(T[] entidade) where T: class;
        Task<bool> SalvaMudancas();

    }
}
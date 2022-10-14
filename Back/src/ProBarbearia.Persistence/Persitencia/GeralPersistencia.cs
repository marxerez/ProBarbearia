using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Persistence.Contextos;
using ProBarbearia.Persistence.Contratos;

namespace ProBarbearia.Persistence
{
    public class GeralPersistencia : IGeralPersistencia
    {
        private readonly ProBarbeariaContext _contexto;

        public GeralPersistencia(ProBarbeariaContext contexto)
        {
            _contexto = contexto;
        }
        public void Adiciona<T>(T entidade) where T : class
        {
            _contexto.AddAsync(entidade);
        }

        public void Atualiza<T>(T entidade) where T : class
        {
            _contexto.Update(entidade);
        }

        public void Deleta<T>(T entidade) where T : class
        {
            _contexto.Remove(entidade);
        }

        public void DeletaVarios<T>(T[] entidade) where T : class
        {
            _contexto.RemoveRange(entidade);
        }

        public async Task<bool> SalvaMudancas()
        {
            return (await _contexto.SaveChangesAsync())> 0;
        }
    }
}
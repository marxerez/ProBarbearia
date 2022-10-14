using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Application.Contratos;
using ProBarbearia.Persistence.Contratos;
using AutoMapper;
using ProBarbearia.Application.Dtos;

namespace ProBarbearia.Application.Services
{
    public class CidadeServico : ICidadeServico
    {
        private readonly IGeralPersistencia _geralPersistencia;
        private readonly ICidadePersistencia _cidadePersistencia;
        private readonly IMapper _mapper;
        public CidadeServico(IGeralPersistencia geralPersistencia,
                             ICidadePersistencia cidadePersistencia,
                             IMapper mapper)
        {
            _geralPersistencia = geralPersistencia;
            _cidadePersistencia = cidadePersistencia;
            _mapper = mapper;
        }

        public async Task<ListaCidadeDto[]> CarregaCidades(int estadoId)
        {
            try
            {
                var cidades = await _cidadePersistencia.CarregaCidades(estadoId);
                if (cidades == null) return null;

                var resultado = _mapper.Map<ListaCidadeDto[]>(cidades);

                

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
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
    public class EstadoServico : IEstadoServico
    {
        private readonly IGeralPersistencia _geralPersistencia;
        private readonly IEstadoPersistencia _estadoPersistencia;
        private readonly IMapper _mapper;
        public EstadoServico(IGeralPersistencia geralPersistencia,
                             IEstadoPersistencia estadoPersistencia,
                             IMapper mapper)
        {
            _geralPersistencia = geralPersistencia;
            _estadoPersistencia = estadoPersistencia;
            _mapper = mapper;
        }

        public async Task<ListaEstadoDto[]> CarregaEstados()
        {
            try
            {
                var estados = await _estadoPersistencia.CarregaEstados();
                if (estados == null) return null;

                var resultado = _mapper.Map<ListaEstadoDto[]>(estados);

                

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
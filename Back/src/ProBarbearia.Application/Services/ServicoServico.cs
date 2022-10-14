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
    public class ServicoServico : IServicoServico
    {
        private readonly IGeralPersistencia _geralPersistencia;
        private readonly IServicoPersistencia _servicoPersistencia;
        private readonly IMapper _mapper;
        public ServicoServico(IGeralPersistencia geralPersistencia,
                             IServicoPersistencia servicoPersistencia,
                             IMapper mapper)
        {
            _geralPersistencia = geralPersistencia;
            _servicoPersistencia = servicoPersistencia;
            _mapper = mapper;
        }

        public async Task<ServicoDto[]> CarregaServicos(int estabelecimentoId,int profissionalId)
        {
            try
            {
                var servicos = await _servicoPersistencia.CarregaServicos(estabelecimentoId,profissionalId);
                if (servicos == null) return null;

                var resultado = _mapper.Map<ServicoDto[]>(servicos);

                

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

         public async Task<ServicoDto[]> CarregaServicosNaoAssociado(int estabelecimentoId,int profissionalId)
        {
            try
            {
                var servicos = await _servicoPersistencia.CarregaServicosNaoAssociado(estabelecimentoId,profissionalId);
                if (servicos == null) return null;

                var resultado = _mapper.Map<ServicoDto[]>(servicos);

                

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
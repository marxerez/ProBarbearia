using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Application.Contratos;
using ProBarbearia.Application.Dtos.Estabelecimento;
using ProBarbearia.Persistence.Contratos;
using AutoMapper;

namespace ProBarbearia.Application.Services
{
    public class EstabelecimentoServico : IEstabelecimentoServico
    {
        private readonly IGeralPersistencia _geralPersistencia;
        private readonly IEstabelecimentoPersistencia _estabelecimentoPersistencia;
        private readonly IMapper _mapper;
        public EstabelecimentoServico(IGeralPersistencia geralPersistencia,
                             IEstabelecimentoPersistencia estabelecimentoPersistencia,
                             IMapper mapper)
        {
            _geralPersistencia = geralPersistencia;
            _estabelecimentoPersistencia = estabelecimentoPersistencia;
            _mapper = mapper;
        }

        public async Task<ListaEstabelecimentoDto[]> CarregaEstabelecimentosPorUsuario(int idUsuario)
        {
            try
            {
                var estabelecimentos = await _estabelecimentoPersistencia.CarregaEstabelecimentosPorUsuario(idUsuario);
                if (estabelecimentos == null) return null;

                var resultado = _mapper.Map<ListaEstabelecimentoDto[]>(estabelecimentos);



                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ListaEstabelecimentoDto[]> CarregaEstabelecimentoNaoRegistrado(int idUsuario, string nome, int estadoId, int cidadeId)
        {
            try
            {
                var estabelecimentos = await _estabelecimentoPersistencia.CarregaEstabelecimentoNaoRegistrado(idUsuario, nome, estadoId, cidadeId);
                if (estabelecimentos == null) return null;

                var resultado = _mapper.Map<ListaEstabelecimentoDto[]>(estabelecimentos);



                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
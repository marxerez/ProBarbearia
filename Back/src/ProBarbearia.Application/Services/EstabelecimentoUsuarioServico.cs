using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Application.Contratos;
using ProBarbearia.Application.Dtos.Estabelecimento;
using ProBarbearia.Persistence.Contratos;
using AutoMapper;
using ProBarbearia.Application.Dtos.EstabelecimentoUsuario;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Application.Services
{
    public class EstabelecimentoUsuarioServico : IEstabelecimentoUsuarioServico
    {
        private readonly IGeralPersistencia _geralPersistencia;
        private readonly IEstabelecimentoUsuarioPersistencia _estabelecimentoUsuarioPersistencia;
        private readonly IMapper _mapper;
        public EstabelecimentoUsuarioServico(IGeralPersistencia geralPersistencia,
                             IEstabelecimentoUsuarioPersistencia estabelecimentoUsuarioPersistencia,
                             IMapper mapper)
        {
            _geralPersistencia = geralPersistencia;
            _estabelecimentoUsuarioPersistencia = estabelecimentoUsuarioPersistencia;
            _mapper = mapper;
        }

        public async Task<EstabelecimentoUsuarioDto> CarregaEstabelecimentoUsuario(int estabelecimentoId, int usuarioId)
        {
            try
            {
                var estabelecimentoUsuario = await _estabelecimentoUsuarioPersistencia.CarregaEstabelecimentoUsuario(estabelecimentoId, usuarioId);
                if (estabelecimentoUsuario == null) return null;

                var resultado = _mapper.Map<EstabelecimentoUsuarioDto>(estabelecimentoUsuario);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AdicionaEstabelecimentoUsuario(EstabelecimentoUsuarioDto estabelecimentoUsuario)
        {
            try
            {
                var _estabelecimentoUsuario = _mapper.Map<EstabelecimentoUsuario>(estabelecimentoUsuario);
                           
                _geralPersistencia.Adiciona<EstabelecimentoUsuario>(_estabelecimentoUsuario);
                return await _geralPersistencia.SalvaMudancas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

         public async Task<bool> DeletaEstabelecimentoUsuario(EstabelecimentoUsuarioDto estabelecimentoUsuario)
        {
            try
            {
                var _estabelecimentoUsuario = _mapper.Map<EstabelecimentoUsuario>(estabelecimentoUsuario);
                           
                _geralPersistencia.Deleta<EstabelecimentoUsuario>(_estabelecimentoUsuario);
                return await _geralPersistencia.SalvaMudancas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
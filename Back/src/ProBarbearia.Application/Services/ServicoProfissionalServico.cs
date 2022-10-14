using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Application.Contratos;
using ProBarbearia.Persistence.Contratos;
using AutoMapper;
using ProBarbearia.Application.Dtos;
using ProBarbearia.Application.Dtos.ServicoProfissional;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Application.Services
{
    public class ServicoProfissionalServico : IServicoProfissionalServico
    {
        private readonly IGeralPersistencia _geralPersistencia;
        private readonly IServicoProfissionalPersistencia _servicoProfissionalPersistencia;
        private readonly IMapper _mapper;
        public ServicoProfissionalServico(IGeralPersistencia geralPersistencia,
                             IServicoProfissionalPersistencia servicoProfissionalPersistencia,
                             IMapper mapper)
        {
            _geralPersistencia = geralPersistencia;
            _servicoProfissionalPersistencia = servicoProfissionalPersistencia;
            _mapper = mapper;
        }


        public async Task<ServicoProfissionalDto[]> CarregaServicoProfissionais(int estabelecimentoId, int servicoId)
        {
            try
            {
                var profissionais = await _servicoProfissionalPersistencia.CarregaServicoProfissionais(estabelecimentoId, servicoId);
                if (profissionais == null) return null;


                var resultado = _mapper.Map<ServicoProfissionalDto[]>(profissionais);



                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServicoProfissionalEditarDto> CarregaServicoProfissional(int profissionalId, int servicoId)
        {
            try
            {
                var servicoProfissional = await _servicoProfissionalPersistencia.CarregaServicoProfissional(profissionalId, servicoId);
                if (servicoProfissional == null) return null;

                var resultado = _mapper.Map<ServicoProfissionalEditarDto>(servicoProfissional);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> AdicionaServicoProfissional(ServicoProfissionalEditarDto servicoProfissionalEditarDto)
        {
            try
            {
                var _servicoProfissionalEditar = _mapper.Map<ServicoProfissional>(servicoProfissionalEditarDto);

                _geralPersistencia.Adiciona<ServicoProfissional>(_servicoProfissionalEditar);
                return await _geralPersistencia.SalvaMudancas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletaServicoProfissional(ServicoProfissionalEditarDto servicoProfissionalEditarDto)
        {
            try
            {
                var _servicoProfissionalEditar = _mapper.Map<ServicoProfissional>(servicoProfissionalEditarDto);

                _geralPersistencia.Deleta<ServicoProfissional>(_servicoProfissionalEditar);
                return await _geralPersistencia.SalvaMudancas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
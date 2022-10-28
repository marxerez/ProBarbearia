using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Application.Contratos;
using ProBarbearia.Persistence.Contratos;
using AutoMapper;
using ProBarbearia.Application.Dtos;
using ProBarbearia.Domain.Models;
using Microsoft.AspNetCore.Identity;
using ProBarbearia.Domain.Identity;

namespace ProBarbearia.Application.Services
{
    public class ProfissionalServico : IProfissionalServico
    {
        private readonly IGeralPersistencia _geralPersistencia;
        private readonly IProfissionalPersistencia _profissionalPersistencia;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IUsuarioPersistencia _usuarioPersistencia;
        public ProfissionalServico(IGeralPersistencia geralPersistencia,
                             IProfissionalPersistencia profissionalPersistencia,
                             IMapper mapper,
                             UserManager<User> userManager,
                             IUsuarioPersistencia usuarioPersistencia)
        {
            _geralPersistencia = geralPersistencia;
            _profissionalPersistencia = profissionalPersistencia;
            _mapper = mapper;
            _userManager = userManager;
            _usuarioPersistencia = usuarioPersistencia;
        }

        public async Task<ProfissionalRetornoDto[]> CarregaProfissionais(int estabelecimentoId)
        {
            try
            {
                var profissionais = await _profissionalPersistencia.CarregaProfissionais(estabelecimentoId);
                if (profissionais == null) return null;


                var resultado = _mapper.Map<ProfissionalRetornoDto[]>(profissionais);



                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProfissionalRetornoDto[]> CarregaProfissionaisPorNome(int estabelecimentoId, string nomeProfissional)
        {
            try
            {
                var profissionais = await _profissionalPersistencia.CarregaProfissionaisPorNome(estabelecimentoId, nomeProfissional);
                if (profissionais == null) return null;


                var resultado = _mapper.Map<ProfissionalRetornoDto[]>(profissionais);



                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

          public async Task<UsuarioProfissionalDto> CarregaProfissionalPorId(int estabelecimentoId,int usuarioId)
        {
            try
            {
                var profissional = await _profissionalPersistencia.CarregaProfissionalPorId(estabelecimentoId, usuarioId);
                if (profissional == null) return null;

                var resultado = _mapper.Map<UsuarioProfissionalDto>(profissional);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AdicionaProfissional(UsuarioProfissionalDto usuarioProfissional)
        {
            try
            {
                var _usuarioProfissional = _mapper.Map<Profissional>(usuarioProfissional);

                _geralPersistencia.Adiciona<Profissional>(_usuarioProfissional);
                var retorno = await _geralPersistencia.SalvaMudancas();
                if (retorno)
                {
                    var usuario = await _usuarioPersistencia.CarregaUsuarioPorNome(usuarioProfissional.userName);
                    if (usuario == null) return false;
                    var resultRole = await _userManager.AddToRoleAsync(usuario, "PROFISSIONAL");

                    if (resultRole.Succeeded)
                        return retorno;
                }
                
                 return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletaProfissional(UsuarioProfissionalDto usuarioProfissional)
        {
            try
            {
                var _usuarioProfissional = _mapper.Map<Profissional>(usuarioProfissional);

                _geralPersistencia.Deleta<Profissional>(_usuarioProfissional);
                var retorno = await _geralPersistencia.SalvaMudancas();
                if (retorno)
                {
                    var usuario = await _usuarioPersistencia.CarregaUsuarioPorId(usuarioProfissional.UserId);
                    if (usuario == null) return false;
                    var resultRole = await _userManager.RemoveFromRoleAsync(usuario, "PROFISSIONAL");

                    if (resultRole.Succeeded)
                        return retorno;
                }
                
                 return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




    }
}
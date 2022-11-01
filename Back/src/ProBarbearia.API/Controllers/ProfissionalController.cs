using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProBarbearia.API.Extensions;
using ProBarbearia.Application.Contratos;
using ProBarbearia.Application.Dtos;
using ProBarbearia.Application.Services;

namespace ProBarbearia.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalController : ControllerBase
    {



        public readonly IProfissionalServico _profissionalServico;

        public ProfissionalController(IProfissionalServico profissionalServico)
        {
            _profissionalServico = profissionalServico;

        }

        [HttpGet("profissionais")]
        [AllowAnonymous]

        public async Task<IActionResult> CarregaProfissionais(int estabelecimentoId)
        {
            try
            {

                var profissionais = await _profissionalServico.CarregaProfissionais(estabelecimentoId);
                if (profissionais == null) return NoContent();

                return Ok(profissionais);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Profissionais. Erro: {ex.Message}");
            }
        }
        [HttpGet("pesquisa")]
        [AllowAnonymous]
        public async Task<IActionResult> CarregaProfissionaisPorNome(int estabelecimentoId, string nomeProfissional)
        {
            try
            {

                var profissionais = await _profissionalServico.CarregaProfissionaisPorNome(estabelecimentoId, nomeProfissional);
                if (profissionais == null) return NoContent();

                return Ok(profissionais);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Profissionais. Erro: {ex.Message}");
            }
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AdicionaProfissional(UsuarioProfissionalDto usuarioProfissionalDto)
        {
            try
            {

                if (await _profissionalServico.AdicionaProfissional(usuarioProfissionalDto))
                {
                    return Ok(new { retorno = "Adicionado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problema não específico ao tentar Marcar a agenda nesse Horário.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar marcar um horário na agenda do Profissional. Erro: {ex.Message}");
            }
        }

        [HttpDelete("deleta")]
        [AllowAnonymous]
        public async Task<IActionResult> DeletaProfissional(int estabelecimentoId, int usuarioId)
        {
            try
            {
                var profissional = await _profissionalServico.CarregaProfissionalPorId(estabelecimentoId, usuarioId);
                if (profissional == null) return NoContent();

                if (await _profissionalServico.DeletaProfissional(profissional))
                {
                    return Ok(new { retorno = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problema não específico ao tentar desativar o profissional.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar desativar o profissional. Erro: {ex.Message}");
            }
        }



    }
}
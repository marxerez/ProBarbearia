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
    public class ServicoController : ControllerBase
    {



        public readonly IServicoServico _servicoServico;

        public ServicoController(IServicoServico servicoServico)
        {
            _servicoServico = servicoServico;

        }

        [HttpGet("servicos")]
        [AllowAnonymous]

        public async Task<IActionResult> CarregaServicos(int estabelecimentoId, int profissionalId)
        {
            try
            {

                var servicos = await _servicoServico.CarregaServicos(estabelecimentoId, profissionalId);
                if (servicos == null) return NoContent();

                return Ok(servicos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Serviços do Profissional. Erro: {ex.Message}");
            }
        }

        [HttpGet("servicosNaoAssociado")]
        [AllowAnonymous]

        public async Task<IActionResult> CarregaServicosNaoAssociado(int estabelecimentoId, int profissionalId)
        {
            try
            {

                var servicos = await _servicoServico.CarregaServicosNaoAssociado(estabelecimentoId, profissionalId);
                if (servicos == null) return NoContent();

                return Ok(servicos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Serviços do Estabelecimento. Erro: {ex.Message}");
            }
        }

    }
}
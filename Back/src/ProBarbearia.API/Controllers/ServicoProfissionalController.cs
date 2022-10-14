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
using ProBarbearia.Application.Dtos.ServicoProfissional;
using ProBarbearia.Application.Services;

namespace ProBarbearia.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ServicoProfissionalController : ControllerBase
    {

        
        
        public readonly IServicoProfissionalServico _servicoProfissionalServico ;
        
        public ServicoProfissionalController(IServicoProfissionalServico servicoProfissionalServico)
        {
            _servicoProfissionalServico = servicoProfissionalServico;
            
        }

     
    [HttpGet("servicoProfissionais")]
    [AllowAnonymous]
         public async Task<IActionResult> CarregaServicoProfissionais(int estabelecimentoId, int servicoId, int profissionalId)
        {
            try
            {
                
                var profissionais = await _servicoProfissionalServico.CarregaServicoProfissionais(estabelecimentoId,servicoId);
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
        public async Task<IActionResult> AdicionaServicoProfissional(ServicoProfissionalEditarDto servicoProfissionalEditarDto)
        {
            try
            {

      

                if (await _servicoProfissionalServico.AdicionaServicoProfissional(servicoProfissionalEditarDto))
                {
                    return Ok(new { retorno = "Adicionado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problema não específico ao tentar adicionar o serviço do profissional.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar o serviço do profissional. Erro: {ex.Message}");
            }
        }

        [HttpDelete("deleta")]
        [AllowAnonymous]
        public async Task<IActionResult> DeletaServicoProfissional(int profissionalId,int servicoId)
        {
            try
            {
                var servicoProfissional = await _servicoProfissionalServico.CarregaServicoProfissional(profissionalId, servicoId);
                if (servicoProfissional == null) return NoContent();

                if (await _servicoProfissionalServico.DeletaServicoProfissional(servicoProfissional))
                {
                    return Ok(new { retorno = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problema não específico ao tentar remover o serviço do profissional.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar remover o serviço do profissional. Erro: {ex.Message}");
            }
        }
        
    }
}
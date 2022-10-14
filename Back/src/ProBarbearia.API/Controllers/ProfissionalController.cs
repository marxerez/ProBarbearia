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

        
        
        public readonly IProfissionalServico _profissionalServico ;
        
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
   

        
        
    }
}
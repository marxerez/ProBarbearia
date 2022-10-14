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
    public class CidadeController : ControllerBase
    {

        
        
        public readonly ICidadeServico _cidadeServico ;
        
        public CidadeController(ICidadeServico cidadeServico)
        {
            _cidadeServico = cidadeServico;
            
        }

      [HttpGet("{estadoId}")]
      
      
        public async Task<IActionResult> CarregaCidades(int estadoId)
        {
            try
            {
                
                var cidades = await _cidadeServico.CarregaCidades(estadoId);
                if (cidades == null) return NoContent();

                return Ok(cidades);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Cidades. Erro: {ex.Message}");
            }
        }
        
    }
}
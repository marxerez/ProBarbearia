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
    public class EstadoController : ControllerBase
    {

        
        
        public readonly IEstadoServico _estadoServico ;
        
        public EstadoController(IEstadoServico estadoServico)
        {
            _estadoServico = estadoServico;
            
        }

      [HttpGet("")]
      
      
        public async Task<IActionResult> CarregaEstados()
        {
            try
            {
                
                var estados = await _estadoServico.CarregaEstados();
                if (estados == null) return NoContent();

                return Ok(estados);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Estados. Erro: {ex.Message}");
            }
        }
        
    }
}
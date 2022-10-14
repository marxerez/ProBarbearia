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
    public class EstabelecimentoController : ControllerBase
    {


        private readonly IUsuarioServico _usuarioServico;
        private readonly ITokenServico _tokenServico;
        public readonly IEstabelecimentoServico _estabelecimentoServico;

        public EstabelecimentoController(IUsuarioServico usuarioServico,
                                 ITokenServico tokenServico,
                                 IEstabelecimentoServico estabelecimentoServico
                                  )
        {
            _estabelecimentoServico = estabelecimentoServico;
            _usuarioServico = usuarioServico;
            _tokenServico = tokenServico;

        }

        [HttpGet("")]

        public async Task<IActionResult> CarregaEstabelecimentosPorUsuario()
        {
            try
            {
                //Acessa o ID do usuário logado através da Classe de extensão ClaimsPrincipalExtensions que carrega os dados da classe System.Security.Claims;
                var estabelecimentos = await _estabelecimentoServico.CarregaEstabelecimentosPorUsuario(User.GetUserId());
                if (estabelecimentos == null) return NoContent();

                return Ok(estabelecimentos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Estabelecimentos do Usuário. Erro: {ex.Message}");
            }
        }

        [HttpGet("pesquisa")]
        

        public async Task<IActionResult> CarregaEstabelecimentoNaoRegistrado(string nome, int estadoId=0, int cidadeId=0)
        {
            try
            {
                //Acessa o ID do usuário logado através da Classe de extensão ClaimsPrincipalExtensions que carrega os dados da classe System.Security.Claims;
                var estabelecimentos = await _estabelecimentoServico.CarregaEstabelecimentoNaoRegistrado(User.GetUserId(),nome, estadoId, cidadeId);
                if (estabelecimentos == null) return NoContent();

                return Ok(estabelecimentos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Lista de Estabelecimentos. Erro: {ex.Message}");
            }
        }

        
        


    }
}
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
using ProBarbearia.Application.Dtos.EstabelecimentoUsuario;
using ProBarbearia.Application.Services;

namespace ProBarbearia.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EstabelecimentoUsuarioController : ControllerBase
    {


        private readonly IUsuarioServico _usuarioServico;
        private readonly ITokenServico _tokenServico;
        public readonly IEstabelecimentoUsuarioServico _estabelecimentoUsuarioServico;

        public EstabelecimentoUsuarioController(IUsuarioServico usuarioServico,
                                 ITokenServico tokenServico,
                                 IEstabelecimentoUsuarioServico estabelecimentoUsuarioServico
                                  )
        {
            _estabelecimentoUsuarioServico = estabelecimentoUsuarioServico;
            _usuarioServico = usuarioServico;
            _tokenServico = tokenServico;

        }



        [HttpGet("adiciona")]
        
        public async Task<IActionResult> AdicionaEstabelecimentoUsuario(int estabelecimentoId)
        {
            try
            {
                // var estabelecimentoUsuario = await _estabelecimentoUsuarioServico.CarregaEstabelecimentoUsuario(estabelecimentoId ,5);//User.GetUserId()
                // if (estabelecimentoUsuario == null) return NoContent();
                EstabelecimentoUsuarioDto estabelecimentoUsuario = new EstabelecimentoUsuarioDto();
                estabelecimentoUsuario.UserId = User.GetUserId();
                estabelecimentoUsuario.EstabelecimentoID= estabelecimentoId;


                if (await _estabelecimentoUsuarioServico.AdicionaEstabelecimentoUsuario(estabelecimentoUsuario))
                {
                    return Ok(new { retorno = "Adicionado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problem não específico ao tentar Associar o usuário ao Estabelecimento.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Associar o usuário ao Estabelecimento. Erro: {ex.Message}");
            }
        }

        [HttpDelete("deleta")]
        
        public async Task<IActionResult> DeletaEstabelecimentoUsuario(int estabelecimentoId)
        {
            try
            {
                var estabelecimentoUsuario = await _estabelecimentoUsuarioServico.CarregaEstabelecimentoUsuario(estabelecimentoId ,User.GetUserId());
                if (estabelecimentoUsuario == null) return NoContent();

                if (await _estabelecimentoUsuarioServico.DeletaEstabelecimentoUsuario(estabelecimentoUsuario))
                {
                    return Ok(new { retorno = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problem não específico ao tentar remover a associação do usuário com o Estabelecimento.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar remover a associação do usuário com o Estabelecimento. Erro: {ex.Message}");
            }
        }


    }
}
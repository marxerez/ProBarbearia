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
    public class UsuarioController : ControllerBase
    {

        UsuarioRetornoDto usuarioRetornoDto;
        private readonly IUsuarioServico _usuarioServico;
        private readonly ITokenServico _tokenServico;

        public UsuarioController(IUsuarioServico usuarioServico,
                                 ITokenServico tokenServico
                                  )
        {
            _usuarioServico = usuarioServico;
            _tokenServico = tokenServico;

        }

        [HttpPost("Registrar")]
        [AllowAnonymous]
        public async Task<IActionResult> Registrar(UsuarioDto usuarioDto)
        {
            try
            {
                if (await _usuarioServico.UsuarioExiste(usuarioDto.UserName))
                    return BadRequest("Usuário já existe");

                var UsuarioRetornoDto = await _usuarioServico.RegistraUsuario(usuarioDto);
                if (UsuarioRetornoDto != null)
                    return Ok(UsuarioRetornoDto);

                return BadRequest("Não foi possível registrar o usuário, tente novamente mais tarde!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Registrar Usuário. Erro: {ex.Message}");
            }
        }

        [HttpGet("UsuarioLogado")]

        public async Task<IActionResult> GetUser()
        {
            try
            {
                var userName = User.GetUserName();

                var usuarioRetornoDto = await _usuarioServico.CarregaUsuarioPorNome(userName);
                return Ok(usuarioRetornoDto);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Usuário. Erro: {ex.Message}");
            }
        }

        [HttpGet("UsuarioProfissionalId")]

        public async Task<IActionResult> UsuarioProfissionalId(int usuarioId)
        {
            try
            {

                var usuarioRetornoDto = await _usuarioServico.CarregaUsuarioPorId(usuarioId);
                return Ok(usuarioRetornoDto);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Profissional. Erro: {ex.Message}");
            }
        }

        [HttpPost("Logar")]
        [AllowAnonymous]
        public async Task<IActionResult> Logar(UsuarioLoginDto userLogin)
        {
            try
            {
                var usuarioRetornoDto = await _usuarioServico.CarregaUsuarioPorNome(userLogin.UserName);
                if (usuarioRetornoDto == null) return Unauthorized("Usuário ou Senha está errado");

                var result = await _usuarioServico.VerificaSenhaUsuario(usuarioRetornoDto, userLogin.Password);
                if (!result.Succeeded) return Unauthorized("Usuário ou Senha está errado");



                return Ok(usuarioRetornoDto);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar realizar Login. Erro: {ex.Message}");
            }
        }

        [HttpPut("AtualizaUsuario")]
        public async Task<IActionResult> AtualizaUsuario(UsuarioAtualizaDto usuarioAtualizaDto)
        {
            try
            {
                if (usuarioAtualizaDto.UserName != User.GetUserName())  //Método de extensão da System.Security.Claims; ClaimsPrincipal
                    return Unauthorized("Usuário Inválido");

                // var usuarioRetornoDto = await _usuarioServico.CarregaUsuarioPorNome(User.GetUserName());
                // if (usuarioRetornoDto == null) return Unauthorized("Usuário Inválido");

                var usuarioRetornoDto = await _usuarioServico.AtualizaUsuario(usuarioAtualizaDto);
                if (usuarioRetornoDto == null) return NoContent();

                return Ok(usuarioRetornoDto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Atualizar Usuário. Erro: {ex.Message}");
            }
        }

        [HttpGet("ListaUsuarios")]


        public async Task<IActionResult> CarregaUsuariosPorNome(string nomeUsuario)
        {
            try
            {

                var usuarios = await _usuarioServico.CarregaUsuariosPorNome(nomeUsuario);
                if (usuarios == null) return NoContent();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar listar usuários. Erro: {ex.Message}");
            }
        }

        [HttpGet("ListaUsuariosNaoProfissionais")]


        public async Task<IActionResult> CarregaUsuariosNaoProfissionais(string nomeUsuario, int estabelecimentoId)
        {
            try
            {

                var usuarios = await _usuarioServico.CarregaUsuariosNaoProfissionais(nomeUsuario, estabelecimentoId);
                if (usuarios == null) return NoContent();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar listar usuários. Erro: {ex.Message}");
            }
        }

    }
}
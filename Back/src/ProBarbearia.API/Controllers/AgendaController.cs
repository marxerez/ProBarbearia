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
using ProBarbearia.Application.Dtos.Agenda;
using ProBarbearia.Application.Services;

namespace ProBarbearia.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AgendaController : ControllerBase
    {


        private readonly IUsuarioServico _usuarioServico;
        private readonly ITokenServico _tokenServico;
        public readonly IAgendaServico _agendaServico;

        public AgendaController(IUsuarioServico usuarioServico,
                                 ITokenServico tokenServico,
                                 IAgendaServico agendaServico
                                  )
        {
            _agendaServico = agendaServico;
            _usuarioServico = usuarioServico;
            _tokenServico = tokenServico;

        }
        [HttpGet("minhaAgenda")]
        

        public async Task<IActionResult> CarregaMinhaAgenda(int estabelecimentoId)
        {
            try
            {
                //Acessa o ID do usuário logado através da Classe de extensão ClaimsPrincipalExtensions que carrega os dados da classe System.Security.Claims;
                var minhaAgenda = await _agendaServico.CarregaAgenda(User.GetUserId(), estabelecimentoId);
                if (minhaAgenda == null) return NoContent();

                return Ok(minhaAgenda);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Lista de Estabelecimentos. Erro: {ex.Message}");
            }
        }
    

        [HttpPost]
        
        public async Task<IActionResult> AdicionaAgenda(AgendaDto agendaDto)
        {
            try
            {

                agendaDto.UserAtendenteId = User.GetUserId();
               // agendaDto.UserClienteId = User.GetUserId();
                var dataSemTempo =  agendaDto.DataAgendamento;//agendaDto.DataAgendamento.ToLocalTime();
                agendaDto.DataAgendamento = dataSemTempo.Date;

                if (await _agendaServico.AdicionaAgenda(agendaDto))
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
        
        public async Task<IActionResult> DeletaAgendaUsuario(int agendaId)
        {
            try
            {
                var agenda = await _agendaServico.CarregaAgendaUsuario(agendaId);
                if (agenda == null) return NoContent();

                if (await _agendaServico.DeletaAgenda(agenda))
                {
                    return Ok(new { retorno = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problema não específico ao tentar remover o agendamento do usuário.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar remover o agendamento do usuário. Erro: {ex.Message}");
            }
        }


    }




}

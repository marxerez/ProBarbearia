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
using ProBarbearia.Application.Dtos.Agenda;
using ProBarbearia.Application.Services;

namespace ProBarbearia.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalHorarioController : ControllerBase
    {



        public readonly IProfissionalHorarioServico _profissionalHorarioServico;
        private readonly IAgendaServico _agendaServico;


        public ProfissionalHorarioController(IProfissionalHorarioServico profissionalHorarioServico, IAgendaServico agendaServico)
        {
            _profissionalHorarioServico = profissionalHorarioServico;
            _agendaServico = agendaServico;
        }

        [HttpGet("pesquisa")]


        public async Task<IActionResult> CarregaProfissionalHorarios([FromQuery] AgendaDto agendaDto, Boolean gerenciaAgenda, string modoExibicao)
        {
            try
            {
                agendaDto.UserAtendenteId = User.GetUserId();
                agendaDto.UserClienteId = User.GetUserId();


                var agendaHorarioDto = await _agendaServico.CarregaAgendaHorario(agendaDto, modoExibicao);

                var profissionalHorarios = await _profissionalHorarioServico.CarregaProfissionalHorarios(agendaDto, agendaHorarioDto, gerenciaAgenda, modoExibicao);
                if (profissionalHorarios == null) return NoContent();

                //merge de arrays no angular 
                //   var changedObjects = profissionalHorarios.Concat(agendaUsuario).filter(x => !arr2.find(y => y.hora== x.hora));


                return Ok(profissionalHorarios);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Horarios do Profissional. Erro: {ex.Message}");
            }
        }

        [HttpGet("profissionalHorariosEditar")]

        public async Task<IActionResult> CarregaProfissionalHorariosEditar(int profissionalId)
        {
            try
            {

                var profissionalHorarios = await _profissionalHorarioServico.CarregaProfissionalHorariosEditar(profissionalId);
                if (profissionalHorarios == null) return NoContent();

                return Ok(profissionalHorarios);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar horários do profissional. Erro: {ex.Message}");
            }
        }

        [HttpPost]

        public async Task<IActionResult> AdicionaProfissionalHorario(ProfissionalHorarioEditarDto profissionalHorarioEditarDto)
        {
            try
            {

                var dataSemTempo = profissionalHorarioEditarDto.HoraAbertura.ToLocalTime();
                profissionalHorarioEditarDto.HoraAbertura = dataSemTempo;

                dataSemTempo = profissionalHorarioEditarDto.HoraFechamento.ToLocalTime();
                profissionalHorarioEditarDto.HoraFechamento = dataSemTempo;

                if (await _profissionalHorarioServico.AdicionaProfissionalHorario(profissionalHorarioEditarDto))
                {
                    return Ok(new { retorno = "Adicionado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problema não específico ao tentar adicionar o horário do profissional.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar o horário do profissional. Erro: {ex.Message}");
            }
        }

        [HttpDelete("deleta")]
        
        public async Task<IActionResult> DeletaProfissionalHorario(int id)
        {
            try
            {
                var profissionalHorario = await _profissionalHorarioServico.CarregaProfissionalHorarioPorId(id);
                if (profissionalHorario == null) return NoContent();

                if (await _profissionalHorarioServico.DeletaProfissionalHorario(profissionalHorario))
                {
                    return Ok(new { retorno = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problema não específico ao tentar remover o horário do profissional.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar remover o horário do profissional. Erro: {ex.Message}");
            }
        }

    }
}
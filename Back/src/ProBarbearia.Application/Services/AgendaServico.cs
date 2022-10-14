using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Application.Contratos;
using ProBarbearia.Application.Dtos.Estabelecimento;
using ProBarbearia.Persistence.Contratos;
using AutoMapper;
using ProBarbearia.Application.Dtos.Agenda;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Application.Services
{
    public class AgendaServico : IAgendaServico
    {
        private readonly IGeralPersistencia _geralPersistencia;
        private readonly IAgendaPersistencia _agendaPersistencia;
        private readonly IMapper _mapper;
        public AgendaServico(IGeralPersistencia geralPersistencia,
                             IAgendaPersistencia agendaPersistencia,
                             IMapper mapper)
        {
            _geralPersistencia = geralPersistencia;
            _agendaPersistencia = agendaPersistencia;
            _mapper = mapper;
        }


        public async Task<AgendaDto> CarregaAgendaUsuario(int agendaId)
        {
            try
            {
                var agenda = await _agendaPersistencia.CarregaAgendaUsuario(agendaId);
                if (agenda == null) return null;

                var resultado = _mapper.Map<AgendaDto>(agenda);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<AgendaRetornoDto[]> CarregaAgenda(int usuarioId, int estabelecimentoId)
        {
            try
            {


                var agenda = await _agendaPersistencia.CarregaAgenda(usuarioId, estabelecimentoId);
                if (agenda == null) return null;

                var resultado = _mapper.Map<AgendaRetornoDto[]>(agenda);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AgendaHorarioDto[]> CarregaAgendaHorario(AgendaDto agendaDto,string modoExibicao)
        {
            try
            {
                var agendaParametros = _mapper.Map<Agenda>(agendaDto);

                var agenda = await _agendaPersistencia.CarregaAgendaHorario(agendaParametros,modoExibicao);
                if (agenda == null) return null;

                var resultado = _mapper.Map<AgendaHorarioDto[]>(agenda);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       

        public async Task<bool> AdicionaAgenda(AgendaDto agenda)
        {
            try
            {
                var _agenda = _mapper.Map<Agenda>(agenda);

                _geralPersistencia.Adiciona<Agenda>(_agenda);
                return await _geralPersistencia.SalvaMudancas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

         public async Task<bool> DeletaAgenda(AgendaDto agenda)
        {
            try
            {
                var _agenda = _mapper.Map<Agenda>(agenda);

                _geralPersistencia.Deleta<Agenda>(_agenda);
                return await _geralPersistencia.SalvaMudancas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Application.Contratos;
using ProBarbearia.Persistence.Contratos;
using ProBarbearia.Domain.Models;
using AutoMapper;
using ProBarbearia.Application.Dtos;
using ProBarbearia.Application.Dtos.Agenda;
using System.Collections;

namespace ProBarbearia.Application.Services
{
    public class ProfissionalHorarioServico : IProfissionalHorarioServico
    {
        private readonly IGeralPersistencia _geralPersistencia;
        private readonly IProfissionalHorarioPersistencia _ProfissionalHorarioPersistencia;

        private readonly IMapper _mapper;
        public List<AgrupadoPorProfissionalHorarioDto> agrupadoPorProfissionalHorarioLista;
        public AgrupadoPorProfissionalHorarioDto agrupadoPorProfissionalHorario;
        public List<NovoProfissionalHorarioDto> novoProfissionalLista;
        public List<NovoProfissionalHorarioDto> novoProfissionalLista2;
        public NovoProfissionalHorarioDto novoProfissional;
        public NovoProfissionalHorarioDto novoProfissional2;
        public List<HorarioDto> listaHorarios;
        public ProfissionalHorarioServico(IGeralPersistencia geralPersistencia,
                             IProfissionalHorarioPersistencia ProfissionalHorarioPersistencia,

                             IMapper mapper)
        {
            _geralPersistencia = geralPersistencia;
            _ProfissionalHorarioPersistencia = ProfissionalHorarioPersistencia;

            _mapper = mapper;
        }


        //backup AgrupadoPorProfissionalHorarioDto NovoProfissionalHorarioDto
        public async Task<AgrupadoPorProfissionalHorarioDto[]> CarregaProfissionalHorarios(AgendaDto agendaDto, AgendaHorarioDto[] agendaHorarioDto, bool gerenciaAgenda, string modoExibicao)
        {
            try
            {
                var agendaParametros = _mapper.Map<Agenda>(agendaDto);
                var profissionalHorarios = await _ProfissionalHorarioPersistencia.CarregaProfissionalHorarios(agendaParametros, gerenciaAgenda, modoExibicao);
                if (profissionalHorarios == null) return null;

                var resultado = _mapper.Map<ProfissionalHorarioDto[]>(profissionalHorarios);

                foreach (ProfissionalHorarioDto item in resultado)
                {
                    var horaInicial = item.HoraAbertura;
                    var horaFinal = item.HoraFechamento;
                    var tempoAtendimento = item.DuracaoAtendimento;
                    var profissionalIdAtual = item.ProfissionalId;
                    var diaSemanaAtual = item.DiaSemana;
                    var listaHorarios = new List<HorarioDto>();

                    for (var hora = horaInicial; hora <= horaFinal; hora = hora.AddMinutes(tempoAtendimento))
                    {
                        var horaAtual = new HorarioDto();
                        horaAtual.Hora = hora;
                        horaAtual.ProfissionalId = profissionalIdAtual;
                        horaAtual.DiaSemana = diaSemanaAtual;
                        if (gerenciaAgenda)
                        {
                            horaAtual.AgendaHorario = agendaHorarioDto.Where(x => x.DiaAgendado == horaAtual.DiaSemana && x.HoraAgendada == horaAtual.Hora && x.ProfissionalId == horaAtual.ProfissionalId).FirstOrDefault();
                            listaHorarios.Add(horaAtual);
                        }
                        else
                        {
                            if (!agendaHorarioDto.Any(x => x.DiaAgendado == item.DiaSemana && x.HoraAgendada == horaAtual.Hora && x.ProfissionalId == horaAtual.ProfissionalId))
                                listaHorarios.Add(horaAtual);
                        }
                    }
                    item.Horarios = listaHorarios;

                }
                var idProfissional = 0;
                var diaAgendadoAtual = -1;

                var idProfissionalSemanal = 0;


                novoProfissionalLista2 = new List<NovoProfissionalHorarioDto>();
                agrupadoPorProfissionalHorarioLista = new List<AgrupadoPorProfissionalHorarioDto>();

                int diaSemana = (int)agendaParametros.DataAgendamento.DayOfWeek;
                DateTime dtInicial = agendaParametros.DataAgendamento.AddDays(-diaSemana);
                DateTime dtFinal = agendaParametros.DataAgendamento.AddDays(7 - diaSemana - 1);
                var listadatas = new List<DateTime>();
                for (var dt = dtInicial; dt <= dtFinal; dt = dt.AddDays(1))
                {
                    listadatas.Add(dt);
                }


                foreach (ProfissionalHorarioDto item in resultado)
                {
                    if (idProfissional != item.ProfissionalId || diaAgendadoAtual != item.DiaSemana)
                    {

                        if (modoExibicao == "semanal" && idProfissional != item.ProfissionalId)
                        {
                            agrupadoPorProfissionalHorario = new AgrupadoPorProfissionalHorarioDto();
                            novoProfissionalLista = new List<NovoProfissionalHorarioDto>();
                            novoProfissional = new NovoProfissionalHorarioDto();
                            novoProfissional.DiaSemana = item.DiaSemana;
                            novoProfissional.DataAgendamento = listadatas.Where(x => (int)x.DayOfWeek == item.DiaSemana).FirstOrDefault();
                            novoProfissional.profissional = item.profissional;
                            novoProfissional.Horarios = item.Horarios;

                            agrupadoPorProfissionalHorario.profissional = item.profissional;
                            diaAgendadoAtual = item.DiaSemana;
                            idProfissional = item.ProfissionalId;

                        }
                        else
                        {
                            if (modoExibicao == "diario")
                            {
                                agrupadoPorProfissionalHorario = new AgrupadoPorProfissionalHorarioDto();
                                novoProfissionalLista = new List<NovoProfissionalHorarioDto>();
                                novoProfissional = new NovoProfissionalHorarioDto();
                                novoProfissional.DiaSemana = item.DiaSemana;
                                novoProfissional.DataAgendamento = listadatas.Where(x => (int)x.DayOfWeek == item.DiaSemana).FirstOrDefault();
                                novoProfissional.profissional = item.profissional;
                                novoProfissional.Horarios = item.Horarios;

                                agrupadoPorProfissionalHorario.profissional = item.profissional;
                                diaAgendadoAtual = item.DiaSemana;
                                idProfissional = item.ProfissionalId;
                            }
                            else
                            {

                                novoProfissional = new NovoProfissionalHorarioDto();
                                novoProfissional.DiaSemana = item.DiaSemana;
                                novoProfissional.DataAgendamento = listadatas.Where(x => (int)x.DayOfWeek == item.DiaSemana).FirstOrDefault();
                                novoProfissional.profissional = item.profissional;
                                novoProfissional.Horarios = item.Horarios;

                                diaAgendadoAtual = item.DiaSemana;
                                idProfissional = item.ProfissionalId;

                            }

                        }



                    }
                    else
                    {

                        novoProfissional.Horarios.AddRange(item.Horarios);
                        novoProfissionalLista.Add(novoProfissional);

                        if (modoExibicao == "semanal" && idProfissionalSemanal != item.ProfissionalId)
                        {
                            agrupadoPorProfissionalHorario.profissionalHorariosAgrupado = novoProfissionalLista;
                            agrupadoPorProfissionalHorarioLista.Add(agrupadoPorProfissionalHorario);
                            idProfissionalSemanal = item.ProfissionalId;
                        }
                        else
                        {
                            if (modoExibicao == "semanal" && diaAgendadoAtual != item.DiaSemana)
                                agrupadoPorProfissionalHorario.profissionalHorariosAgrupado.AddRange(novoProfissionalLista);

                            if (modoExibicao == "diario")
                            {
                                agrupadoPorProfissionalHorario.profissionalHorariosAgrupado = novoProfissionalLista;
                                agrupadoPorProfissionalHorarioLista.Add(agrupadoPorProfissionalHorario);
                            }

                        }

                    }
                }
                // if (modoExibicao == "semanal")
                //     agrupadoPorProfissionalHorarioLista.Add(agrupadoPorProfissionalHorario);

                var resultadoAgrupado = agrupadoPorProfissionalHorarioLista.ToArray();
                return resultadoAgrupado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        public async Task<ProfissionalHorarioEditarDto[]> CarregaProfissionalHorariosEditar(int profissionalId)
        {
            try
            {
                var profissionalHorarios = await _ProfissionalHorarioPersistencia.CarregaProfissionalHorariosEditar(profissionalId);
                if (profissionalHorarios == null) return null;

                var resultado = _mapper.Map<ProfissionalHorarioEditarDto[]>(profissionalHorarios);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProfissionalHorarioEditarDto> CarregaProfissionalHorarioPorId(int id)
        {
            try
            {
                var profissionalHorario = await _ProfissionalHorarioPersistencia.CarregaProfissionalHorarioPorId(id);
                if (profissionalHorario == null) return null;

                var resultado = _mapper.Map<ProfissionalHorarioEditarDto>(profissionalHorario);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> AdicionaProfissionalHorario(ProfissionalHorarioEditarDto profissionalHorarioEditarDto)
        {
            try
            {
                var _profissionalHorarioEditarDto = _mapper.Map<ProfissionalHorario>(profissionalHorarioEditarDto);

                _geralPersistencia.Adiciona<ProfissionalHorario>(_profissionalHorarioEditarDto);
                return await _geralPersistencia.SalvaMudancas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletaProfissionalHorario(ProfissionalHorarioEditarDto profissionalHorarioEditarDto)
        {
            try
            {
                var _profissionalHorarioEditarDto = _mapper.Map<ProfissionalHorario>(profissionalHorarioEditarDto);

                _geralPersistencia.Deleta<ProfissionalHorario>(_profissionalHorarioEditarDto);
                return await _geralPersistencia.SalvaMudancas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
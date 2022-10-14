using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProBarbearia.Application.Dtos;
using ProBarbearia.Application.Dtos.Agenda;
using ProBarbearia.Application.Dtos.Estabelecimento;
using ProBarbearia.Application.Dtos.EstabelecimentoUsuario;
using ProBarbearia.Application.Dtos.ServicoProfissional;
using ProBarbearia.Domain.Identity;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Application.Profiles
{
    public class ProBarbeariaProfile : Profile
    {
        public ProBarbeariaProfile()
        {
            CreateMap<User, UsuarioDto>().ReverseMap();
            CreateMap<User, UsuarioLoginDto>().ReverseMap();
            CreateMap<User, UsuarioAtualizaDto>().ReverseMap();
            CreateMap<User, UsuarioRetornoDto>().ReverseMap();
            CreateMap<UsuarioAtualizaDto, UsuarioRetornoDto>().ReverseMap();
            CreateMap<User, UsuarioAgendaDto>().ReverseMap();

            CreateMap<ListaEstabelecimentoDto, Estabelecimento>().ReverseMap();
            CreateMap<EstabelecimentoDto, Estabelecimento>().ReverseMap();
            CreateMap<ListaCidadeDto, Cidade>().ReverseMap();
            CreateMap<ListaEstadoDto, Estado>().ReverseMap();
            CreateMap<EstabelecimentoNaoRegistradoDto, EstabelecimentoNaoRegistradoView>().ReverseMap();

            CreateMap<EstabelecimentoUsuarioDto, EstabelecimentoUsuario>().ReverseMap();
            CreateMap<EstabelecimentoDto, Estabelecimento>().ReverseMap();
            CreateMap<ProfissionalDto, Profissional>().ReverseMap();

            CreateMap<ServicoDto, Servico>().ReverseMap();
            CreateMap<ProfissionalRetornoDto, Profissional>().ReverseMap();
            CreateMap<ServicoProfissionalEditarDto, ServicoProfissional>().ReverseMap();
             CreateMap<User, ProfissionalDto>().ReverseMap();
             
             CreateMap<ServicoProfissionalDto, ServicoProfissional>().ReverseMap();
             CreateMap<ProfissionalHorarioDto, ProfissionalHorario>().ReverseMap();
             CreateMap<ProfissionalHorarioDto, NovoProfissionalHorarioDto>().ReverseMap();
             CreateMap<ProfissionalHorario, ProfissionalHorarioEditarDto>().ReverseMap();
             

             CreateMap<AgendaDto, Agenda>().ReverseMap();
             CreateMap<AgendaHorarioDto, Agenda>().ReverseMap();
             CreateMap<AgendaRetornoDto, Agenda>().ReverseMap();
             
            
        }

    }
}
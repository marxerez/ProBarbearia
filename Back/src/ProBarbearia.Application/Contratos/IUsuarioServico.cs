using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProBarbearia.Application.Dtos;

namespace ProBarbearia.Application.Contratos
{
    public interface IUsuarioServico
    {
        Task<bool> UsuarioExiste(string nomeUsuario);
        Task<UsuarioRetornoDto> CarregaUsuarioPorNome(string nomeUsuario);
        Task<UsuarioRetornoDto> CarregaUsuarioPorId(int usuarioId);
        Task<UsuarioAgendaDto[]> CarregaUsuariosPorNome(string nomeUsuario);
        Task<UsuarioProfissionalDto[]> CarregaUsuariosNaoProfissionais(string nomeUsuario, int estabelecimentoId);
        
        Task<SignInResult> VerificaSenhaUsuario(UsuarioRetornoDto usuarioRetornoDto, string senha);
        Task<UsuarioRetornoDto> AtualizaUsuario(UsuarioAtualizaDto usuarioAtualizaDto);
        Task<UsuarioRetornoDto> RegistraUsuario(UsuarioDto usuarioDto);


    }
}
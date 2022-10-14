using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProBarbearia.Application.Dtos;
using ProBarbearia.Application.Services;
using ProBarbearia.Domain.Identity;
using ProBarbearia.Persistence.Contratos;

namespace ProBarbearia.Application.Contratos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUsuarioPersistencia _usuarioPersistencia;
        private readonly ITokenServico _tokenServico;

        private UsuarioRetornoDto usuarioRetornoDto;

        public UsuarioServico(UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              IMapper mapper,
                              IUsuarioPersistencia usuarioPersistencia,
                              ITokenServico tokenServico
                              )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _usuarioPersistencia = usuarioPersistencia;
            _tokenServico = tokenServico;
        }

        public async Task<UsuarioRetornoDto> RegistraUsuario(UsuarioDto usuarioDto)
        {
            try
            {
                var usuario = _mapper.Map<User>(usuarioDto);
                var result = await _userManager.CreateAsync(usuario, usuarioDto.Password);

                if (!result.Succeeded)
                    return null;

                var resultRole = await _userManager.AddToRoleAsync(usuario, "CLIENTE");


                if (resultRole.Succeeded)
                {

//                    var usuarioAtualizado = _mapper.Map<UsuarioAtualizaDto>(usuario);


                    usuarioRetornoDto = _mapper.Map<UsuarioRetornoDto>(usuario);

                    var listaRoles = new List<RoleDto>{
                        new RoleDto { Id = 2, Name = "CLIENTE" }
                    };

                    usuarioRetornoDto.Roles = listaRoles;
                    usuarioRetornoDto.Token = _tokenServico.GeraToken(usuarioRetornoDto).Result;

                    return usuarioRetornoDto;
                }

                return null;
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar Criar Usuário. Erro: {ex.Message}");
            }
        }
        public async Task<bool> UsuarioExiste(string nomeUsuario)
        {
            try
            {
                return await _userManager.Users
                                         .AnyAsync(user => user.UserName == nomeUsuario.ToLower());
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao verificar se usuário existe. Erro: {ex.Message}");
            }
        }

        public async Task<UsuarioRetornoDto> AtualizaUsuario(UsuarioAtualizaDto usuarioAtualizaDto)
        {
            try
            {
                var usuario = await _usuarioPersistencia.CarregaUsuarioPorNome(usuarioAtualizaDto.UserName);
                if (usuario == null) return null;

                usuarioAtualizaDto.Id = usuario.Id;

                _mapper.Map(usuarioAtualizaDto, usuario);

                if (usuarioAtualizaDto.Password != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
                    await _userManager.ResetPasswordAsync(usuario, token, usuarioAtualizaDto.Password);
                }

                _usuarioPersistencia.Atualiza<User>(usuario);

                if (await _usuarioPersistencia.SalvaMudancas())
                {
                    var usuarioRetorno = await _usuarioPersistencia.CarregaUsuarioPorNome(usuario.UserName);
                   // var usuarioAtualizado = _mapper.Map<UsuarioAtualizaDto>(usuario);

                    var listaRoles = usuarioRetorno.UserRoles.Select(x => new { x.Role.Id, x.Role.Name });

                    usuarioRetornoDto = _mapper.Map<UsuarioRetornoDto>(usuarioRetorno);

                    usuarioRetornoDto.Roles = listaRoles.Select(x => new RoleDto { Id = x.Id, Name = x.Name }).ToList();
                    usuarioRetornoDto.Token = _tokenServico.GeraToken(usuarioRetornoDto).Result;

                    return usuarioRetornoDto;
                }

                return null;
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar atualizar usuário. Erro: {ex.Message}");
            }
        }

        public async Task<UsuarioRetornoDto> CarregaUsuarioPorNome(string nomeUsuario)
        {
            try
            {
                var usuario = await _usuarioPersistencia.CarregaUsuarioPorNome(nomeUsuario);
                if (usuario == null) return null;

               // var usuarioAtualizado = _mapper.Map<UsuarioAtualizaDto>(usuario);

                var listaRoles = usuario.UserRoles.Select(x => new { x.Role.Id, x.Role.Name });

                usuarioRetornoDto = _mapper.Map<UsuarioRetornoDto>(usuario);

                usuarioRetornoDto.Roles = listaRoles.Select(x => new RoleDto { Id = x.Id, Name = x.Name }).ToList();
                usuarioRetornoDto.Token = _tokenServico.GeraToken(usuarioRetornoDto).Result;

                return usuarioRetornoDto;
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar pegar Usuário por Username. Erro: {ex.Message}");
            }
        }

         public async Task<UsuarioRetornoDto> CarregaUsuarioPorId(int usuarioId)
        {
            try
            {
                var usuario = await _usuarioPersistencia.CarregaUsuarioPorId(usuarioId);
                if (usuario == null) return null;

               // var usuarioAtualizado = _mapper.Map<UsuarioAtualizaDto>(usuario);

                var listaRoles = usuario.UserRoles.Select(x => new { x.Role.Id, x.Role.Name });

                usuarioRetornoDto = _mapper.Map<UsuarioRetornoDto>(usuario);

                usuarioRetornoDto.Roles = listaRoles.Select(x => new RoleDto { Id = x.Id, Name = x.Name }).ToList();
                usuarioRetornoDto.Token = _tokenServico.GeraToken(usuarioRetornoDto).Result;

                return usuarioRetornoDto;
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar pegar Usuário por Username. Erro: {ex.Message}");
            }
        }

        public async Task<SignInResult> VerificaSenhaUsuario(UsuarioRetornoDto usuarioRetornoDto, string senha)
        {
            try
            {
                var usuario = await _userManager.Users
                                             .SingleOrDefaultAsync(user => user.UserName == usuarioRetornoDto.UserName.ToLower());

                return await _signInManager.CheckPasswordSignInAsync(usuario, senha, false);
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar password. Erro: {ex.Message}");
            }
        }

          public async Task<UsuarioAgendaDto[]> CarregaUsuariosPorNome(string nomeUsuario)
        {
            try
            {
                var usuarios = await _usuarioPersistencia.CarregaUsuariosPorNome(nomeUsuario);
                if (usuarios == null) return null;

                var resultado = _mapper.Map<UsuarioAgendaDto[]>(usuarios);

                

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
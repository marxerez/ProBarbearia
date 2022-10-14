using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Application.Dtos;

namespace ProBarbearia.Application.Services
{
    public interface ITokenServico
    {
        Task<string> GeraToken(UsuarioRetornoDto usuarioRetornoDto);
    }
}
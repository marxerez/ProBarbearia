using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Application.Dtos.EstabelecimentoUsuario;

namespace ProBarbearia.Application.Contratos
{
    public interface IEstabelecimentoUsuarioServico
    {

        Task<bool> AdicionaEstabelecimentoUsuario(EstabelecimentoUsuarioDto estabelecimentoUsuario);
        Task<bool> DeletaEstabelecimentoUsuario(EstabelecimentoUsuarioDto estabelecimentoUsuario);

        Task<EstabelecimentoUsuarioDto> CarregaEstabelecimentoUsuario(int estabelecimentoId,int usuarioId);
        
    }
}
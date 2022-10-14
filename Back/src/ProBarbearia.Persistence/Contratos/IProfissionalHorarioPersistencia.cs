using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Models;

namespace ProBarbearia.Persistence.Contratos
{
    public interface IProfissionalHorarioPersistencia: IGeralPersistencia
    {
        Task<ProfissionalHorario[]> CarregaProfissionalHorarios( Agenda agenda,bool gerenciaAgenda, string modoExibicao);
        Task<ProfissionalHorario[]> CarregaProfissionalHorariosEditar(int profissionalId);
        Task<ProfissionalHorario> CarregaProfissionalHorarioPorId( int id);
        

    }
}
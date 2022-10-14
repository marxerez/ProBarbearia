using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Application.Dtos.Estabelecimento;

namespace ProBarbearia.Application.Dtos.Agenda
{
    public class AgendaRetornoDto
    {
        public int Id { get; set; }

        public DateTime HoraAgendada { get; set; }

        public DateTime DataAgendamento { get; set; }

        public string Observacao { get; set; }

        public ProfissionalRetornoDto Profissional { get; set; }


        public EstabelecimentoDto Estabelecimento { get; set; }

        public ServicoDto Servico { get; set; }



    }
}
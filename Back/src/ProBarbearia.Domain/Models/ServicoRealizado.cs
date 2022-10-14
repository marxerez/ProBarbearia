using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Identity;

namespace ProBarbearia.Domain.Models
{
    public class ServicoRealizado
    {
        public int Id { get; set; }

        public int AtendimentoId { get; set; }
        public Atendimento Atendimento { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
        public decimal QtdServico { get; set; }
        public int? ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }



    }
}
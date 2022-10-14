using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Identity;

namespace ProBarbearia.Domain.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        public int AgendaId { get; set; }
        public Agenda Agenda { get; set; }
        public DateTime DataAtendimento { get; set; }
        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public IEnumerable<ServicoRealizado> ServicosRealizados { get; set; }
    }
}
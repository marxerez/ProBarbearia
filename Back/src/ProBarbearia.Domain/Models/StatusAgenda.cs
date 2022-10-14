using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProBarbearia.Domain.Models
{
    public class StatusAgenda
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<Agenda> Agendas { get; set; }
    }
}
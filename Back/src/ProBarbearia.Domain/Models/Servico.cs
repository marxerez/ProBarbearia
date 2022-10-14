using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProBarbearia.Domain.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }
        public int EstabelecimentoID { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        public IEnumerable<ServicoProfissional> ServicosProfissionais { get; set; }
         public IEnumerable<Agenda> Agendas { get; set; }
         public IEnumerable<ServicoRealizado> ServicosRealizados { get; set; }
    }
}
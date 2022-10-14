using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Identity;

namespace ProBarbearia.Domain.Models
{
    public class Profissional
    {
       public int Id { get; set; }
       // public string Foto { get; set; }
       
        public string MiniCurriculo { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        public IEnumerable<RedeSocial> RedesSociais { get; set; }
        public IEnumerable<Avaliacao> Avaliacoes { get; set; }

        public IEnumerable<Agenda> Agendas { get; set; }
        public  IEnumerable<ServicoProfissional> ServicosProfissionais { get; set; }
        public IEnumerable<ServicoRealizado> ServicosRealizados { get; set; }


    }
}
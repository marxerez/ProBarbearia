using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Domain.Identity;

namespace ProBarbearia.Domain.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int Nota { get; set; }
        public string Comentario { get; set; }
        public DateTime DataComentario { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }

        public int? ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }

    }
}
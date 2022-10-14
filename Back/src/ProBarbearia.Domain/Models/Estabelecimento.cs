using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProBarbearia.Domain.Models
{
    public class Estabelecimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string LogoMarcaImagem { get; set; }
        public string GoogleMaps { get; set; }
        public string Endereço { get; set; }
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }
        //  public int EstadoId { get; set; }
        //  public Estado Estado { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string InformacaoAdicional { get; set; }
        public IEnumerable<EstabelecimentoUsuario> EstabelecimentosUsuarios { get; set; }
        public IEnumerable<EstabelecimentoHorario> EstabelecimentoHorarios { get; set; }
        public IEnumerable<RedeSocial> RedesSociais { get; set; }
        public IEnumerable<FormaPagamento> FormasPagamentos { get; set; }
        public IEnumerable<Avaliacao> Avaliacoes { get; set; }
        public IEnumerable<Servico> Servicos { get; set; }
        public IEnumerable<Agenda> Agendas { get; set; }
        public IEnumerable<Profissional> Profissionais { get; set; }

    }
}
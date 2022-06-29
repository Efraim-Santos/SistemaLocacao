using SistemaLocacao.Core.Model;
using System;

namespace SistemaLocacao.Domain.Entity
{
    public class LocacaoEntity : EntityBase
    {
        public int IdCliente { get; set; }
        public int IdFilme { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }

        private LocacaoEntity()
        {}
        public ClienteEntity Cliente{ get; set; }
        public FilmeEntity Filme{ get; set; }

        public LocacaoEntity(int idCliente, int idFilme, DateTime dataDevolucao)
        {
            IdCliente = idCliente;
            IdFilme = idFilme;
            DataDevolucao = dataDevolucao;
            DataLocacao = DateTime.Now.Date;
        }

        public void AlterarEntidade(int idFilme, DateTime dataDevolucao)
        {
            IdFilme = idFilme;
            DataDevolucao = dataDevolucao;
            DataLocacao = DateTime.Now;
        }
    }
}
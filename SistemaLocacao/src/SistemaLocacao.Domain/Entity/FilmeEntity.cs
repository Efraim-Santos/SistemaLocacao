using SistemaLocacao.Core.Model;
using System;

namespace SistemaLocacao.Domain.Entity
{
    public class FilmeEntity : EntityBase
    {
        public string Titulo { get; set; }
        public int ClassificaoIndicativa { get; set; }
        public Byte Lancamento { get; set; }

        public LocacaoEntity Locacao { get; set; }

        private FilmeEntity()
        {}

        public FilmeEntity(string titulo, int classificaoIndicativa, byte lancamento)
        {
            Titulo = titulo;
            ClassificaoIndicativa = classificaoIndicativa;
            Lancamento = lancamento;
        }
    }
}

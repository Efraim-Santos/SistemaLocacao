using System;

namespace SistemaLocacao.API.ViewModels
{
    public class FilmeViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int ClassificaoIndicativa { get; set; }
        public Byte Lancamento { get; set; }
    }
}

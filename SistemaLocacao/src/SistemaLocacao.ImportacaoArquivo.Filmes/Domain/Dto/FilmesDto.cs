using System;

namespace SistemaLocacao.ImportacaoArquivo.Filmes.Domain.Dto
{
    internal class FilmesDto
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string ClassificaoIndicativa { get; set; }
        public string Lancamento { get; set; }
    }
}

using System.Collections.Generic;

namespace SistemaLocacao.API.ViewModels
{
    public class RelatorioGeralViewModel
    {
        public IEnumerable<ClienteViewModel> ClientesEmAtraso { get; set; }
        public IEnumerable<FilmeViewModel> FilmesNaoAlugados { get; set; }
        public IEnumerable<FilmeViewModel> FilmesMaisAlugadosAnoTop5 { get; set; }
        public IEnumerable<FilmeViewModel> FilmesMenosAlugados { get; set; }

        public ClienteViewModel ClienteMaisAlugouTop2 { get; set; }
    }
}

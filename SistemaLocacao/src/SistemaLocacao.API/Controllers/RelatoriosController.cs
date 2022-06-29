using Microsoft.AspNetCore.Mvc;
using SistemaLocacao.API.Extension;
using SistemaLocacao.API.Services;
using SistemaLocacao.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaLocacao.API.Controllers
{
    [Route("api/v1/Relatorios")]
    [ApiController]
    public class RelatoriosController : BaseController
    {
        private readonly IRelatoriosService _relatoriosService;

        public RelatoriosController(IRelatoriosService relatoriosService)
        {
            _relatoriosService = relatoriosService;
        }

        /// <summary>
        /// Clientes em atraso na devolução
        /// </summary>
        /// <returns></returns>
        [HttpGet("download/clientes-em-atraso")]
        public async Task<IActionResult> DownloadClientesEmAtraso()
        {
            var clienteEmAtrasoDelolucao = await _relatoriosService.ClienteEmAtrasoDelolucao();

            var result = ExportarArquivo.Exportar(clienteEmAtrasoDelolucao, nameof(clienteEmAtrasoDelolucao));

            return File(result.stream, result.caminho, result.nome);
        }

        /// <summary>
        /// Filmes que nunca foram alugados.
        /// </summary>
        /// <returns></returns>
        [HttpGet("download/filmes-nunca-alugados")]
        public async Task<IActionResult> DownloadFilmesNuncaAlugados()
        {
            var filmesQueNuncaForamAlugados = await _relatoriosService.FilmesQueNuncaForamAlugados();

            var result = ExportarArquivo.Exportar(filmesQueNuncaForamAlugados, nameof(filmesQueNuncaForamAlugados));

            return File(result.stream, result.caminho, result.nome);
        }

        /// <summary>
        /// Cinco filmes mais alugados do último ano
        /// </summary>
        /// <returns></returns>
        [HttpGet("download/filmes-mais-alugados")]
        public async Task<IActionResult> DownloadFilmesMaisAlugados()
        {
            var filmesMaisAlugadosAno = await _relatoriosService.FilmesMaisAlugadosAno();

            var result = ExportarArquivo.Exportar(filmesMaisAlugadosAno, nameof(filmesMaisAlugadosAno));

            return File(result.stream, result.caminho, result.nome);
        }

        /// <summary>
        /// Três filmes menos alugados da última semana
        /// </summary>
        /// <returns></returns>
        [HttpGet("download/filmes-menos-alugados")]
        public async Task<IActionResult> DownloadFilmesMenosAlugados()
        {
            var filmesMenosAlugadosSemana = await _relatoriosService.FilmesMenosAlugadosSemana();

            var result = ExportarArquivo.Exportar(filmesMenosAlugadosSemana, nameof(filmesMenosAlugadosSemana));

            return File(result.stream, result.caminho, result.nome);
        }

        /// <summary>
        /// O segundo cliente que mais alugou filmes
        /// </summary>
        /// <returns></returns>
        [HttpGet("download/cliente-mais-alugou")]
        public async Task<IActionResult> DownloadClienteMaisAlugou()
        {
            var clienteMaisAlugou = new List<ClienteViewModel> { await _relatoriosService.ClienteMaisAlugou() };

            var result = ExportarArquivo.Exportar(clienteMaisAlugou, nameof(clienteMaisAlugou));

            return File(result.stream, result.caminho, result.nome);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SistemaLocacao.API.Model;
using SistemaLocacao.API.Services;
using SistemaLocacao.API.ViewModels;
using System.Threading.Tasks;

namespace SistemaLocacao.API.Controllers
{
    [Route("api/v1/Importacoes")]
    [ApiController]
    public class ImportacoesArquivoController : BaseController
    {
        private readonly IImportacoesArquivoService _importacoesArquivoService;

        public ImportacoesArquivoController(IImportacoesArquivoService importacoesArquivoService)
        {
            _importacoesArquivoService = importacoesArquivoService;
        }

        [HttpPost("importar-filmes")]
        public async Task<ActionResult<ResponseModel<ImportacaoViewModel>>> ImportarArquivoDeFilmes([FromBody] ImportacaoViewModel arquivoAnexoBytes)
          => await _importacoesArquivoService.ImportarFilmes(arquivoAnexoBytes);
    }
}

using Microsoft.AspNetCore.Mvc;
using SistemaLocacao.API.Services;
using SistemaLocacao.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaLocacao.API.Controllers
{
    [Route("api/v1/Filme")]
    [ApiController]
    public class FilmeController : BaseController
    {
        private readonly IFilmeService _filmeService;

        public FilmeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        /// <summary>
        /// Listar todos os filmes
        /// </summary>
        /// <returns></returns>
        [HttpGet("listar-filmes")]
        public async Task<IEnumerable<FilmeViewModel>> Get()
        => await _filmeService.ListarFilmes();
    }
}
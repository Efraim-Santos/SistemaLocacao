using Microsoft.AspNetCore.Mvc;
using SistemaLocacao.API.Model;
using SistemaLocacao.API.Services;
using SistemaLocacao.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaLocacao.API.Controllers
{
    [Route("api/v1/Locacao")]
    [ApiController]
    public class LocacaoController : BaseController
    {
        private readonly ILocacaoService _locacaoService;

        public LocacaoController(ILocacaoService locacaoService)
        {
            _locacaoService = locacaoService;
        }

        /// <summary>
        /// Adicionar locacao
        /// </summary>
        /// <param name="locacao">locacao model</param>
        /// <returns></returns>
        [HttpPost("{idCliente}/{idFilme}")]
        public async Task<ActionResult<ResponseModel<LocacaoViewModel>>> Post(int idCliente, int idFilme, DevolverLocacaoViewModel locacao)
            => ExecutarRequestAsync(await _locacaoService.Adicionar(idCliente, idFilme, locacao));

        /// <summary>
        /// Atualizar locacao
        /// </summary>
        /// <param name="idFilme"></param>
        /// <param name="locacao"></param>
        /// <returns></returns>
        [HttpPut("{id}/{idFilme}")]
        public async Task<ActionResult<ResponseModel<LocacaoViewModel>>> Put(int id, int idFilme, DevolverLocacaoViewModel locacao)
           => ExecutarRequestAsync(await _locacaoService.Atualizar(id, idFilme, locacao));

        /// <summary>
        /// Remover locacao
        /// </summary>
        /// <param name="id">Id do locacao</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
          => await _locacaoService.RemoverLocacao(id);

        /// <summary>
        /// Buscar locacao pelo id
        /// </summary>
        /// <param name="id">Id da locacao</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<LocacaoViewModel>> Get(int id)
         => ExecutarGetAsync(await _locacaoService.BuscarLocacaoId(id));

        /// <summary>
        /// Listar todas as locacaos
        /// </summary>
        /// <returns></returns>
        [HttpGet("listar-locacoes")]
        public async Task<IEnumerable<LocacaoViewModel>> Get()
        => await _locacaoService.ListarLocacaos();
    }
}

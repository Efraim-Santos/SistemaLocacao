using Microsoft.AspNetCore.Mvc;
using SistemaLocacao.API.Model;
using SistemaLocacao.API.Services;
using SistemaLocacao.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaLocacao.API.Controllers
{
    [Route("api/v1/Cliente")]
    [ApiController]
    public class ClienteController : BaseController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Adicionar Cliente
        /// </summary>
        /// <param name="cliente">Cliente model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseModel<ClienteViewModel>>> Post(ClienteRequestViewModel cliente)
            => ExecutarRequestAsync(await _clienteService.Adicionar(cliente));

        /// <summary>
        /// Atualizar cliente
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <param name="cliente">Cliente model</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseModel<ClienteViewModel>>> Put(int id, ClienteRequestViewModel cliente)
           => ExecutarRequestAsync(await _clienteService.Atualizar(id, cliente));

        /// <summary>
        /// Remover cliente
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
          => await _clienteService.RemoverCliente(id);

        /// <summary>
        /// Buscar cliente pelo id
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteViewModel>> Get(int id)
         => ExecutarGetAsync(await _clienteService.BuscarClienteId(id));

        /// <summary>
        /// Buscar cliente por nome e cpf
        /// </summary>
        /// <param name="nome">Nome do cliente</param>
        /// <param name="cpf">Cpf do cliente</param>
        /// <returns></returns>
        [HttpGet("{nome}/{cpf}")]
        public async Task<ActionResult<ClienteViewModel>> Get(string nome, string cpf)
            => ExecutarGetAsync(await _clienteService.BuscarRegistroCliente(nome, cpf));

        /// <summary>
        /// Listar todos os clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet("listar-clientes")]
        public async Task<IEnumerable<ClienteViewModel>> Get()
        => await _clienteService.ListarClientes();

    }
}

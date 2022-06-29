using SistemaLocacao.Domain.Data;
using SistemaLocacao.Domain.Entity;
using SistemaLocacao.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaLocacao.Infra.Queries
{
    public class ClienteQuerie : IClienteQuerie
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteQuerie(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        /// <summary>
        /// Buscar cliente por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ClienteEntity> BuscarClienteId(int id)
            => await _clienteRepository.BuscarClientePorFiltro(c => c.Id == id);
        
        /// <summary>
        /// Listar todos os clientes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ClienteEntity>> ObterTodosClientes()
            => await _clienteRepository.ObterTodos();

        /// <summary>
        /// Buscar cliente por nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<ClienteEntity> BuscarClienteNomeCpf(string nome, string cpf)
            => await _clienteRepository.BuscarClientePorFiltro(c => c.Nome.Equals(nome) && c.Cpf.Equals(cpf));
    }
}

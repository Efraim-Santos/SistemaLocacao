using SistemaLocacao.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaLocacao.Domain.Queries
{
    public interface IClienteQuerie
    {
        /// <summary>
        /// Buscar cliente por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ClienteEntity> BuscarClienteId(int id);

        /// <summary>
        /// Listar todos os clientes
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ClienteEntity>> ObterTodosClientes();

        /// <summary>
        /// Buscar cliente por nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        Task<ClienteEntity> BuscarClienteNomeCpf(string nome, string cpf);
    }
}

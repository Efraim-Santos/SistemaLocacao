using SistemaLocacao.API.Model;
using SistemaLocacao.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaLocacao.API.Services
{
    public interface IClienteService
    {
        Task<ResponseModel<ClienteViewModel>> Adicionar(ClienteViewModel cliente);
        Task<ResponseModel<ClienteViewModel>> Atualizar(int id, ClienteViewModel cliente);
        Task<bool> RemoverCliente(int id);
        Task<ClienteViewModel> BuscarClienteId(int id);
        Task<ClienteViewModel> BuscarRegistroCliente(string nome, string cpf);
        Task<IEnumerable<ClienteViewModel>> ListarClientes();
    }
}
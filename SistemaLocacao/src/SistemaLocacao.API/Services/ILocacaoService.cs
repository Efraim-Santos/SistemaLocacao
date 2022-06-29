using SistemaLocacao.API.Model;
using SistemaLocacao.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaLocacao.API.Services
{
    public interface ILocacaoService
    {
        Task<ResponseModel<LocacaoViewModel>> Adicionar(int idCliente, int idFilme, DevolverLocacaoViewModel locacao);
        Task<ResponseModel<LocacaoViewModel>> Atualizar(int idLocacao, int idFilme, DevolverLocacaoViewModel locacao);
        Task<LocacaoViewModel> BuscarLocacaoId(int id);
        Task<IEnumerable<LocacaoViewModel>> ListarLocacaos();
        Task<bool> RemoverLocacao(int id);
    }
}
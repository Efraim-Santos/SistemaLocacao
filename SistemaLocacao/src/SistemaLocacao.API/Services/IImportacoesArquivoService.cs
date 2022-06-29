using SistemaLocacao.API.Model;
using SistemaLocacao.API.ViewModels;
using System.Threading.Tasks;

namespace SistemaLocacao.API.Services
{
    public interface IImportacoesArquivoService
    {
        Task<ResponseModel<ImportacaoViewModel>> ImportarFilmes(ImportacaoViewModel arquivoAnexoBytes);
    }
}
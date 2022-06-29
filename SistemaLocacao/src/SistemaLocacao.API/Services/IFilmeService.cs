using SistemaLocacao.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaLocacao.API.Services
{
    public interface IFilmeService
    {
        Task<IEnumerable<FilmeViewModel>> ListarFilmes();
    }
}
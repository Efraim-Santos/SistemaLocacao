using SistemaLocacao.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaLocacao.API.Services
{
    public interface IRelatoriosService
    {
        //Task<RelatorioGeralViewModel> RelatorioGeral();
        Task<IEnumerable<ClienteViewModel>> ClienteEmAtrasoDelolucao();
        Task<IEnumerable<FilmeViewModel>> FilmesQueNuncaForamAlugados();
        Task<IEnumerable<FilmeViewModel>> FilmesMaisAlugadosAno();
        Task<IEnumerable<FilmeViewModel>> FilmesMenosAlugadosSemana();
        Task<ClienteViewModel> ClienteMaisAlugou();
    }
}
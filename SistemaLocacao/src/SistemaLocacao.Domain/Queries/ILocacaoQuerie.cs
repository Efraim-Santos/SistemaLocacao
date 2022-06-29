using SistemaLocacao.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaLocacao.Domain.Queries
{
    public interface ILocacaoQuerie
    {

        /// <summary>
        /// Buscar locacao por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<LocacaoEntity> BuscarLocacaoId(int id);

        /// <summary>
        /// Buscar locacao por filme
        /// </summary>
        /// <param name="idFilme"></param>
        /// <returns></returns>
        Task<LocacaoEntity> BuscarLocacaoPorFilme(int idFilme);

        /// <summary>
        /// Buscar locacao por cliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        Task<IEnumerable<LocacaoEntity>> BuscarLocacoesPorCliente(int idCliente);

        /// <summary>
        /// Listar todas locacoes
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<LocacaoEntity>> ObterTodasLocacoes();

        /// <summary>
        /// Listar locacoes de filmes em atraso
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<LocacaoEntity>> ListarLocacoesDeFilmesEmAtraso();

        /// <summary>
        /// Listar filmes mais lucados
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<LocacaoEntity>> ListarFilmesMaisLocados();

        /// <summary>
        /// Listar filmes menos locados na semana
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<LocacaoEntity>> ListarFilmesMenosLocadosSemana();

        /// <summary>
        /// Listar cliente que mais alugou
        /// </summary>
        /// <returns></returns>
        Task<LocacaoEntity> ListarClienteQueMaisAlugou();
    }
}

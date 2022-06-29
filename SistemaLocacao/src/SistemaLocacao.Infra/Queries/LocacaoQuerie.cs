using SistemaLocacao.Domain.Data;
using SistemaLocacao.Domain.Entity;
using SistemaLocacao.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaLocacao.Infra.Queries
{
    public class LocacaoQuerie : ILocacaoQuerie
    {
        private readonly ILocacaoRepository _locacaoRepository;

        public LocacaoQuerie(ILocacaoRepository locacaoRepository)
        {
            _locacaoRepository = locacaoRepository;
        }

        /// <summary>
        /// Buscar locacao por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<LocacaoEntity> BuscarLocacaoId(int id)
            => await _locacaoRepository.ObterPorId(id);

        /// <summary>
        /// Buscar locacao por filtro
        /// </summary>
        /// <param name="idFilme"></param>
        /// <returns></returns>
        public async Task<LocacaoEntity> BuscarLocacaoPorFilme(int idFilme)
            => await _locacaoRepository.BuscarLocacaoPorFiltro(f => f.IdFilme == idFilme);

        /// <summary>
        /// Buscar locacoes por filtro
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public async Task<IEnumerable<LocacaoEntity>> BuscarLocacoesEmAtraso()
            => await _locacaoRepository.ListarLocacoesDeFilmesEmAtraso();

        /// <summary>
        /// Buscar locacoes por cliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public async Task<IEnumerable<LocacaoEntity>> BuscarLocacoesPorCliente(int idCliente)
        => await _locacaoRepository.BuscarLocacoesPorFiltro(l => l.IdCliente == idCliente);

        /// <summary>
        /// Listar 5 clientes que mais alugou
        /// </summary>
        /// <returns></returns>
        public async Task<LocacaoEntity> ListarClienteQueMaisAlugou()
            => await _locacaoRepository.ListarClienteQueMaisAlugou();
        
        /// <summary>
        /// Listar filmes mais locados
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LocacaoEntity>> ListarFilmesMaisLocados()
        => await _locacaoRepository.ListarFilmesMaisLocados();

        /// <summary>
        /// Listar 3 filmes menos locado
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LocacaoEntity>> ListarFilmesMenosLocadosSemana()
         => await _locacaoRepository.ListarFilmesMenosLocadosSemana();

        /// <summary>
        /// Listar locacoes em atraso
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LocacaoEntity>> ListarLocacoesDeFilmesEmAtraso()
         => await _locacaoRepository.ListarLocacoesDeFilmesEmAtraso();

        /// <summary>
        /// Listar todas locacoes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LocacaoEntity>> ObterTodasLocacoes()
            => await _locacaoRepository.ObterTodos();
    }
}

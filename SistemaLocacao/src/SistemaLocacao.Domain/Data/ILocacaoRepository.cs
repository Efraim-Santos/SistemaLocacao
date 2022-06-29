using SistemaLocacao.Core.Infra;
using SistemaLocacao.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SistemaLocacao.Domain.Data
{
    public interface ILocacaoRepository : IRepository<LocacaoEntity>
    {

        Task<LocacaoEntity> BuscarLocacaoPorFiltro(Expression<Func<LocacaoEntity, bool>> filtro);
        Task<IEnumerable<LocacaoEntity>> BuscarLocacoesPorFiltro(Expression<Func<LocacaoEntity, bool>> filtro);
        Task<IEnumerable<LocacaoEntity>> ListarLocacoesDeFilmesEmAtraso();
        Task<IEnumerable<LocacaoEntity>> ListarFilmesMaisLocados();
        Task<IEnumerable<LocacaoEntity>> ListarFilmesMenosLocadosSemana();
        Task<LocacaoEntity> ListarClienteQueMaisAlugou();
    }
}
using SistemaLocacao.Core.Infra;
using SistemaLocacao.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SistemaLocacao.Domain.Data
{
    public interface IFilmeRepository : IRepository<FilmeEntity>
    {

        Task<FilmeEntity> BuscarLocacaoPorFiltro(Expression<Func<FilmeEntity, bool>> filtro);

        Task<IEnumerable<FilmeEntity>> BuscarFilmesNuncaLocados();
    }
}

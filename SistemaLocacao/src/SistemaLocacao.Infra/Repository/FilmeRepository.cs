using Microsoft.EntityFrameworkCore;
using SistemaLocacao.Core.Infra;
using SistemaLocacao.Domain.Data;
using SistemaLocacao.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SistemaLocacao.Infra.Repository
{
    public class FilmeRepository : Repository<FilmeEntity>, IFilmeRepository
    {
        public FilmeRepository(SistemaLocacaoContext context) : base(context)
        {}

        public Task<FilmeEntity> BuscarLocacaoPorFiltro(Expression<Func<FilmeEntity, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FilmeEntity>> BuscarFilmesNuncaLocados()
        {
            var filmesLocados = await dbSet
                .Include(f => f.Locacao)
                .AsNoTracking()
                .Where(f => f.Locacao == null)
                .ToListAsync();

            return filmesLocados;
        }
    }
}

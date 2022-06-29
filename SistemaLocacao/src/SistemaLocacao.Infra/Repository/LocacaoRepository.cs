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
    public class LocacaoRepository : Repository<LocacaoEntity>, ILocacaoRepository
    {
        public LocacaoRepository(SistemaLocacaoContext context) : base(context)
        {}

        public async Task<LocacaoEntity> BuscarLocacaoPorFiltro(Expression<Func<LocacaoEntity, bool>> filtro)
        {
            return await dbSet
                .Include(f => f.Cliente)
                .Include(f => f.Filme)
                .AsNoTracking()
                .FirstOrDefaultAsync(filtro);
        }

        public async Task<IEnumerable<LocacaoEntity>> BuscarLocacoesPorFiltro(Expression<Func<LocacaoEntity, bool>> filtro)
        {
            return await dbSet
                .Include(f => f.Cliente)
                .Include(f => f.Filme)
                .AsNoTracking()
                .Where(filtro)
                .ToListAsync();
        }

        public async Task<IEnumerable<LocacaoEntity>> ListarLocacoesDeFilmesEmAtraso()
        {
           return await dbSet
               .Include(f => f.Filme)
               .Include(f => f.Cliente)
               .AsNoTracking()
               .Where(l => (l.Filme.Lancamento == 1 && ((DateTime.Now.Day - l.DataLocacao.Day) > 2)) 
                        || (l.Filme.Lancamento == 0 && ((DateTime.Now.Day - l.DataLocacao.Day) > 3)))
               .ToListAsync();
        }
        public async Task<IEnumerable<LocacaoEntity>> ListarFilmesMaisLocados()
        {
            var locacoes = await dbSet
                .Include(f => f.Filme)
                .AsNoTracking()
                .Where(l => l.DataLocacao.Year == DateTime.Now.Year)
                .ToListAsync();

            var resultado = locacoes
                .OrderBy(l => l.IdFilme)
                .Distinct()
                .Take(5);

            return resultado;
        }

        public async Task<IEnumerable<LocacaoEntity>> ListarFilmesMenosLocadosSemana()
        {
            var locacoes = await dbSet
                .Include(f => f.Filme)
                .AsNoTracking()
                .Where(l => (DateTime.Now.Day - l.DataLocacao.Day) <= 7)
                .ToListAsync();

            var resultado = locacoes
                .OrderByDescending(l => l.IdFilme)
                .Distinct()
                .Take(3);

            return resultado;
        }

        public async Task<LocacaoEntity> ListarClienteQueMaisAlugou()
        {
            var locacoes = await dbSet
                .Include(f => f.Cliente)
                .AsNoTracking()
                .ToListAsync();

            var resultado = locacoes
                .OrderBy(l => l.IdCliente)
                .Distinct()
                .Take(2)
                .LastOrDefault();

            return resultado;
        }
    }
}

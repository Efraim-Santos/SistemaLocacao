using Microsoft.EntityFrameworkCore;
using SistemaLocacao.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaLocacao.Core.Infra
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly DbSet<TEntity> dbSet;
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }

        public IUnitOfWork UnitOfWork => (IUnitOfWork)_context;

        public async Task Adicionar(TEntity entidade)
        {
            var entityDataRegistro = entidade.GetType().GetProperty("DataRegistro");

            if (entityDataRegistro != null)
                entityDataRegistro.SetValue(entidade, Convert.ChangeType(DateTime.Now.Date, entityDataRegistro.PropertyType));

            await dbSet.AddAsync(entidade);
        }
        public void Atualizar(TEntity entidade)
        {
            dbSet.Update(entidade);
        }

        public void Remover(TEntity entidade)
        {
            dbSet.Remove(entidade);
        }
        public async Task<List<TEntity>> ObterTodos()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> ObterPorId(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}

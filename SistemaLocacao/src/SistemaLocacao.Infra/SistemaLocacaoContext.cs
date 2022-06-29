using Microsoft.EntityFrameworkCore;
using SistemaLocacao.Core.Infra;
using SistemaLocacao.Domain.Entity;
using System.Threading.Tasks;

namespace SistemaLocacao.Infra
{
    public class SistemaLocacaoContext : DbContext, IUnitOfWork
    {
        public SistemaLocacaoContext(DbContextOptions<SistemaLocacaoContext> options) : base(options) { }

        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<LocacaoEntity> Locacoes { get; set; }
        public DbSet<FilmeEntity> Filmes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SistemaLocacaoContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}

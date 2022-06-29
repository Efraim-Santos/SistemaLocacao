using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaLocacao.Domain.Entity;

namespace SistemaLocacao.Infra.Configurations
{
    internal class LocacaoConfiguration : IEntityTypeConfiguration<LocacaoEntity>
    {
        public void Configure(EntityTypeBuilder<LocacaoEntity> builder)
        {
            builder.HasKey(l => l.Id);

            builder.HasOne(l => l.Cliente)
                .WithMany(c => c.Locacoes)
                .HasForeignKey(l => l.IdCliente);

            builder.HasOne(l => l.Filme)
                .WithOne(f => f.Locacao)
                .HasForeignKey<LocacaoEntity>(l => l.IdFilme);

            builder.ToTable("Locacoes");
        }
    }
}

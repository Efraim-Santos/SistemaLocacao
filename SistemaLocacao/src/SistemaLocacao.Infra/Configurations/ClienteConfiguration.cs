using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaLocacao.Domain.Entity;

namespace SistemaLocacao.Infra.Configurations
{
    internal class ClienteConfiguration : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Nome)
               .HasColumnType("varchar(11)");

            builder.HasMany(c => c.Locacoes)
                .WithOne(l => l.Cliente)
                .HasForeignKey(l => l.Id);

            builder.ToTable("Clientes");
        }
    }
}

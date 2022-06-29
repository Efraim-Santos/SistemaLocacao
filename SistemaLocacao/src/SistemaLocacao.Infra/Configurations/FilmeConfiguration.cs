using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaLocacao.Domain.Entity;

namespace SistemaLocacao.Infra.Configurations
{
    internal class FilmesConfiguration : IEntityTypeConfiguration<FilmeEntity>
    {
        public void Configure(EntityTypeBuilder<FilmeEntity> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(c => c.Titulo)
              .HasColumnType("varchar(200)");

            builder.Property(c => c.Lancamento)
              .HasColumnType("tinyint");

            builder.ToTable("Filmes");
        }
    }
}

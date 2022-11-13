using ControleVeterinario.Dominio.TipoAnimais;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleVeterinario.Repositorio.Confgs.TipoAnimais
{
    public class TipoAnimalConfig : IEntityTypeConfiguration<TipoAnimal>
    {
        public void Configure(EntityTypeBuilder<TipoAnimal> builder)
        {
            builder.ToTable("CV_TipoAnimal");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Tipo)
                .HasColumnName("Tipo")
                .IsRequired();
        }
    }
}

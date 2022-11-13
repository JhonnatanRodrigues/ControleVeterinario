using ControleVeterinario.Dominio.TipoAnimais.Racas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleVeterinario.Repositorio.Confgs.TipoAnimais.Racas
{
    internal class RacaAnimalConfig : IEntityTypeConfiguration<RacaAnimal>
    {
        public void Configure(EntityTypeBuilder<RacaAnimal> builder)
        {
            builder.ToTable("CV_Raca");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Raca)
                .HasColumnName("Raca")
                .IsRequired();

            builder.Property(p => p.CodigoTipoAnimal)
                .HasColumnName("IdTipoAnimal")
                .IsRequired();

            builder.HasOne(p => p.TipoAnimal)
                .WithMany()
                .HasForeignKey(p => p.CodigoTipoAnimal)
                .IsRequired();
        }
    }
}

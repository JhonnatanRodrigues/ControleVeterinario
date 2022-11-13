using ControleVeterinario.Dominio.Alimentacoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleVeterinario.Repositorio.Confgs.Alimentacoes
{
    internal class AlimentacaoConfig : IEntityTypeConfiguration<Alimentacao>
    {
        public void Configure(EntityTypeBuilder<Alimentacao> builder)
        {
            builder.ToTable("CV_Alimentacao");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CodigoAnimal)
                .HasColumnName("IdAnimal")
                .IsRequired();

            builder.Property(P => P.DataHora_ParoCome)
                .HasColumnName("DataHora_ParoCome")
                .HasColumnType("DateTime");

            builder.Property(P => P.DataHora_FoiCome)
                .HasColumnName("DataHora_FoiCome")
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(p => p.ParoCome)
                .HasColumnName("ParoCome")
                .IsRequired();

            builder.HasOne(p => p.Animal)
                .WithMany()
                .HasForeignKey(p => p.CodigoAnimal)
                .IsRequired();
        }
    }
}

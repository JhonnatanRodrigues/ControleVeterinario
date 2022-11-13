using ControleVeterinario.Dominio.Vacinacoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleVeterinario.Repositorio.Confgs.Vacinacoes
{
    public class VacinacaoConfig : IEntityTypeConfiguration<Vacinacao>
    {
        public void Configure(EntityTypeBuilder<Vacinacao> builder)
        {
            builder.ToTable("CV_Vacinacao");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CodigoRfId)
                .HasColumnName("IdRFID")
                .IsRequired();

            builder.Property(p => p.DataInicioAplicacao)
                .HasColumnName("DataInicioAplicacao")
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(P => P.DataUltimaDose)
                .HasColumnName("DataUltimaDose")
                .HasColumnType("DateTime");

            builder.Property(p => p.QuantDose)
                .HasColumnName("QuantDose")
                .IsRequired();

            builder.Property(p => p.TipoVacinacao)
                .HasColumnName("TipoVacinacao")
                .IsRequired();

            builder.Property(p => p.EmAplicacao)
                .HasColumnName("EmAplicacao");

            builder.HasOne(p => p.RFID)
                .WithMany()
                .HasForeignKey(p => p.CodigoRfId)
                .IsRequired();
        }
    }
}

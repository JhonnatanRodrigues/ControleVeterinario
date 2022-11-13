using ControleVeterinario.Dominio.RFIDs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleVeterinario.Repositorio.Confgs.RFIDs
{
    public class RFIDConfig : IEntityTypeConfiguration<RFID>
    {
        public void Configure(EntityTypeBuilder<RFID> builder)
        {
            builder.ToTable("CV_RFID");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CodigoRFID)
                .HasColumnName("RFID")
                .IsRequired();

            builder.Property(P => P.DataCadastro)
                .HasColumnName("DataCadastro")
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(p => p.EmUso)
                .HasColumnName("EmUso")
                .IsRequired();

            builder.Property(p => p.Ativo)
                .HasColumnName("Ativo")
                .IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ControleVeterinario.Dominio.ControleVeterinarios;

namespace ControleVeterinario.Repositorio.Confgs.ControleVeterinarios
{
    public class CadastroAnimalConfig : IEntityTypeConfiguration<CadastroAnimal>
    {
        public void Configure(EntityTypeBuilder<CadastroAnimal> builder)
        {
            builder.ToTable("CV_CadastroAnimais");

            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.CodigoTipoAnimal)
                .HasColumnName("IdTipoAnimal")
                .IsRequired();

            builder.Property(p => p.CodigoRfId)
                .HasColumnName("IdRFID")
                .IsRequired();

            builder.Property(p => p.CodigoRaca)
                .HasColumnName("IdRaca")
                .IsRequired();

            builder.Property(p => p.DataNacimento)
                .HasColumnName("DataNacimento");

            builder.Property(p => p.Abat_Morte)
                .HasColumnName("abat_morte");

            builder.Property(p => p.DataAbat_Morte)
                .HasColumnName("DataAbat_Morte");

            builder.Property(p => p.Peso)
                .HasColumnName("Peso")
                .IsRequired();

            builder.Property(p => p.Genero)
                .HasColumnName("Genero")
                .IsRequired();


            builder.HasOne(p => p.TipoAnimal)
                .WithMany()
                .HasForeignKey(p => p.CodigoTipoAnimal)
                .IsRequired();

            builder.HasOne(p => p.RFID)
                .WithMany()
                .HasForeignKey(p => p.CodigoRfId)
                .IsRequired();

            builder.HasOne(p => p.Raca)
                .WithMany()
                .HasForeignKey(p => p.CodigoRaca)
                .IsRequired();
        }
    }
}

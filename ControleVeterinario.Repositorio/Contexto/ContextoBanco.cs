using ControleVeterinario.Dominio.Alimentacoes;
using ControleVeterinario.Dominio.ControleVeterinarios;
using ControleVeterinario.Dominio.RFIDs;
using ControleVeterinario.Dominio.TipoAnimais;
using ControleVeterinario.Dominio.TipoAnimais.Racas;
using ControleVeterinario.Repositorio.Confgs.Alimentacoes;
using ControleVeterinario.Repositorio.Confgs.ControleVeterinarios;
using ControleVeterinario.Repositorio.Confgs.RFIDs;
using ControleVeterinario.Repositorio.Confgs.TipoAnimais;
using ControleVeterinario.Repositorio.Confgs.TipoAnimais.Racas;
using Microsoft.EntityFrameworkCore;

namespace ControleVeterinario.Repositorio.Contexto
{
    public class ContextoBanco : DbContext
    {
        public ContextoBanco(DbContextOptions options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RFIDConfig());
            modelBuilder.ApplyConfiguration(new TipoAnimalConfig());
            modelBuilder.ApplyConfiguration(new RacaAnimalConfig());
            modelBuilder.ApplyConfiguration(new AlimentacaoConfig());
            modelBuilder.ApplyConfiguration(new CadastroAnimalConfig());
        }
        public DbSet<RFID> RFIDs { get; set; }
        public DbSet<TipoAnimal> TipoAnimal { get; set; }
        public DbSet<RacaAnimal> RacaAnimal { get; set; }
        public DbSet<Alimentacao> Alimentacao { get; set; }
        public DbSet<CadastroAnimal> CadastroAnimal { get; set; }
    }
}

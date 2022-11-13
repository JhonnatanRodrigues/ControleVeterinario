using ControleVeterinario.Dominio.RFIDs;
using ControleVeterinario.Dominio.TipoAnimais;
using ControleVeterinario.Dominio.TipoAnimais.Racas;

namespace ControleVeterinario.Dominio.ControleVeterinarios
{
    public partial class CadastroAnimal
    {

        public CadastroAnimal()
        {
            RFID = new RFID();
            TipoAnimal = new TipoAnimal();
            Raca = new RacaAnimal();
            Abat_Morte = false;
        }
        public int Id { get; set; }
        public int CodigoRfId { get; set; }
        public int CodigoTipoAnimal { get; set; }
        public int CodigoRaca { get; set; }
        public DateTime? DataNacimento { get; set; }
        public bool? Abat_Morte { get; set; }
        public DateTime? DataAbat_Morte { get; set; }
        public decimal Peso { get; set; }
        public bool Genero { get; set; }

        public RFID RFID{ get; set; }
        public TipoAnimal TipoAnimal { get; set; }
        public RacaAnimal Raca{ get; set; }
    }
}

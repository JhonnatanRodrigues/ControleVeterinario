using ControleVeterinario.Dominio.RFIDs;

namespace ControleVeterinario.Dominio.Alimentacoes
{
    public class Alimentacao
    {
        public int Id { get; set; }
        public int CodigoRfId { get; set; }
        public DateTime DataHora_FoiCome { get; set; }
        public DateTime DataHora_ParoCome { get; set; }

        public RFID RFID { get; set; }
    }
}

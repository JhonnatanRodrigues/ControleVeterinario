using ControleVeterinario.Dominio.RFIDs;

namespace ControleVeterinario.Dominio.Vacinacoes
{
    public class Vacinacao
    {
        public Vacinacao()
        {
            RFID = new RFID();
            EmAplicacao = true;
        }
        public int Id { get; set; }
        public int CodigoRfId { get; set; }
        public DateTime DataInicioAplicacao { get; set; }
        public DateTime? DataUltimaDose { get; set; }
        public decimal QuantDose { get; set; }
        public string TipoVacinacao { get; set; }
        public bool? EmAplicacao { get; set; }

        public RFID RFID { get; set; }

    }
}

namespace ControleVeterinario.Dominio.RFIDs
{
    public class RFID
    {
        public RFID()
        {
            EmUso = false;
        }

        public int Id { get; set; }
        public string CodigoRFID { get; set; }
        public bool EmUso { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}

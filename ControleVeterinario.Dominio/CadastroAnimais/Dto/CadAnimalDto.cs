namespace ControleVeterinario.Dominio.CadastroAnimais.Dto
{
    public class CadAnimalDto
    {
        public int CodigoRfId { get; set; }
        public int CodigoTipoAnimal { get; set; }
        public int CodigoRaca { get; set; }
        public DateTime? DataNacimento { get; set; }
        public decimal Peso { get; set; }
        public bool Genero { get; set; }
    }
}

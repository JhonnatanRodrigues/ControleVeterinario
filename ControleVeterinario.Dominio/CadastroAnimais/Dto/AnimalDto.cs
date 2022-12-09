namespace ControleVeterinario.Dominio.CadastroAnimais.Dto
{
    public class AnimalDto
    {
        public int Id { get; set; }
        public int CodigoRfId { get; set; }
        public int CodigoTipoAnimal { get; set; }
        public int CodigoRaca { get; set; }
        public DateTime? DataNacimento { get; set; }
        public bool? Abat_Morte { get; set; }
        public DateTime? DataAbat_Morte { get; set; }
        public decimal Peso { get; set; }
        public bool Genero { get; set; }
    }
}

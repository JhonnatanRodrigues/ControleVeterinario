namespace ControleVeterinario.Dominio.TipoAnimais.Racas
{
    public class RacaAnimal
    {
        public int Id { get; set; }
        public string Raca { get; set; }
        public int CodigoTipoAnimal { get; set; }

        public TipoAnimal TipoAnimal { get; set; }
    }
}

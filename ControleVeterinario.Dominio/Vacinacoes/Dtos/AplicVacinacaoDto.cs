namespace ControleVeterinario.Dominio.Vacinacoes.Dtos
{
    public class AplicVacinacaoDto
    {
        public int Id { get; set; }
        public DateTime? DataUltimaDoseAplicada { get; set; }
        public decimal QuantDoseAplicada { get; set; }
    }
}

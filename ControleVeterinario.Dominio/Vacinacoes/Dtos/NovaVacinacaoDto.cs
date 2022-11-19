namespace ControleVeterinario.Dominio.Vacinacoes.Dtos
{
    public class NovaVacinacaoDto
    {
        public int CodigoRfId { get; set; }
        public DateTime DataInicioAplicacao { get; set; }
        public decimal QuantDose { get; set; }
        public string TipoVacinacao { get; set; }
        public bool? EmAplicacao { get; set; }
    }
}

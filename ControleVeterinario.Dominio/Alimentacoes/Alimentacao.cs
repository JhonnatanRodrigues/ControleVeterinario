using ControleVeterinario.Dominio.ControleVeterinarios;

namespace ControleVeterinario.Dominio.Alimentacoes
{
    public class Alimentacao
    {
        public int Id { get; set; }
        public int CodigoAnimal { get; set; }
        public DateTime DataHora_FoiCome { get; set; }
        public DateTime? DataHora_ParoCome { get; set; }
        public bool ParoCome { get; set; }

        public CadastroAnimal Animal { get; set; }
    }
}

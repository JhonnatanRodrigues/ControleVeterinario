using ControleVeterinario.Dominio.Alimentacoes;

namespace ControleVeterinario.Aplicacao.Alimentacoes
{
    public interface IAplicAlimentacao
    {
        void FoiAlimentar(string idRfid);
        void ParoAlimentar(string idRfid);
        List<Alimentacao> Listar();
    }
}

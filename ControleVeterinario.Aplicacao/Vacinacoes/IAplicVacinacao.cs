using ControleVeterinario.Dominio.Vacinacoes;
using ControleVeterinario.Dominio.Vacinacoes.Dtos;

namespace ControleVeterinario.Aplicacao.Vacinacoes
{
    public interface IAplicVacinacao 
    {
        List<Vacinacao> Listar();
        void Inserir(NovaVacinacaoDto vacinacaoDto);
        void Aplicacao(AplicVacinacaoDto aplicVacinacaoDto);
    }
}

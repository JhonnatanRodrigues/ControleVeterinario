using ControleVeterinario.Dominio.Alimentacoes;
using System.Linq.Expressions;

namespace ControleVeterinario.Dominio.Vacinacoes
{
    public interface IRepVacinacao
    {
        Task Inserir(Vacinacao vacinacao);
        List<Vacinacao>? Listar();
        IQueryable<Vacinacao>? Where(Expression<Func<Vacinacao, bool>> func);
        void SaveChanges();
    }
}

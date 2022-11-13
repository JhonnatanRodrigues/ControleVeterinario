using ControleVeterinario.Dominio.ControleVeterinarios;
using System.Linq.Expressions;

namespace ControleVeterinario.Dominio.Alimentacoes
{
    public interface IRepAlimentacao
    {
        Task Inserir(Alimentacao alimentacao);
        List<Alimentacao>? Listar();
        IQueryable<Alimentacao>? Where(Expression<Func<Alimentacao, bool>> func);
        void SaveChanges();
    }
}

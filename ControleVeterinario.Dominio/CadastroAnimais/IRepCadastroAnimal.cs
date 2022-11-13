using ControleVeterinario.Dominio.TipoAnimais;
using System.Linq.Expressions;

namespace ControleVeterinario.Dominio.ControleVeterinarios
{
    public interface IRepCadastroAnimal
    {
        Task Inserir(CadastroAnimal cadastroAnimal);
        List<CadastroAnimal>? Listar();
        IQueryable<CadastroAnimal>? Where(Expression<Func<CadastroAnimal, bool>> func);
        void SaveChanges();
    }
}

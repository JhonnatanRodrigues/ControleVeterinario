using System.Linq.Expressions;

namespace ControleVeterinario.Dominio.TipoAnimais
{
    public interface IRepTipoAnimal
    {
        Task Inserir(TipoAnimal tipoAnimal);
        List<TipoAnimal>? Listar();
        void SaveChanges();
        IQueryable<TipoAnimal>? Where(Expression<Func<TipoAnimal, bool>> func);
    }
}

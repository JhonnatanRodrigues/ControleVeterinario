using System.Linq.Expressions;

namespace ControleVeterinario.Dominio.TipoAnimais.Racas
{
    public interface IRepRaca
    {
        Task Inserir(RacaAnimal racaAnimal);
        List<RacaAnimal>? Listar();

        IQueryable<RacaAnimal>? Where(Expression<Func<RacaAnimal, bool>> func);
    }
}

using ControleVeterinario.Dominio.TipoAnimais;
using ControleVeterinario.Repositorio.Contexto;
using System.Linq.Expressions;

namespace ControleVeterinario.Repositorio.Repositorios.TipoAnimais
{
    public class RepTipoAnimal : IRepTipoAnimal
    {
        public readonly ContextoBanco _Db;

        public RepTipoAnimal(ContextoBanco db)
        {
            _Db = db;
        }

        public async Task Inserir(TipoAnimal tipoAnimal)
        {
            await _Db.TipoAnimal.AddAsync(tipoAnimal);
            _Db.SaveChanges();
        }

        public List<TipoAnimal>? Listar()
        {
            return _Db.TipoAnimal.ToList();
        }

        public IQueryable<TipoAnimal>? Where(Expression<Func<TipoAnimal, bool>> func)
        {
            return _Db.TipoAnimal.Where(func);
        }
    }
}

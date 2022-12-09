using ControleVeterinario.Dominio.TipoAnimais.Racas;
using ControleVeterinario.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ControleVeterinario.Repositorio.Repositorios.TipoAnimais.Racas
{
    public class RepRaca : IRepRaca
    {
        public readonly ContextoBanco _Db;

        public RepRaca(ContextoBanco db)
        {
            _Db = db;
        }

        public async Task Inserir(RacaAnimal racaAnimal)
        {
            await _Db.RacaAnimal.AddAsync(racaAnimal);
            _Db.SaveChanges();
        }

        public List<RacaAnimal>? Listar()
        {
            return _Db.RacaAnimal
                .Include(p => p.TipoAnimal).ToList();
        }

        public IQueryable<RacaAnimal>? Where(Expression<Func<RacaAnimal, bool>> func)
        {
            return _Db.RacaAnimal.Where(func)
                                .Include("TipoAnimal");
        }

        public void SaveChanges()
        {
            _Db.SaveChanges();
        }
    }
}

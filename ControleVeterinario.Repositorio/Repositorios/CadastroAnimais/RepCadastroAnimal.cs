using ControleVeterinario.Dominio.ControleVeterinarios;
using ControleVeterinario.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ControleVeterinario.Repositorio.Repositorios.ControleVeterinarios
{
    public class RepCadastroAnimal : IRepCadastroAnimal
    {
        public readonly ContextoBanco _Db;

        public RepCadastroAnimal(ContextoBanco db)
        {
            _Db = db;
        }

        public async Task Inserir(CadastroAnimal  cadastroAnimal)
        {
            try
            {
                await _Db.CadastroAnimal.AddAsync(cadastroAnimal);
                _Db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<CadastroAnimal>? Listar()
        {
            return _Db.CadastroAnimal
                .Include("RFID")
                .Include("TipoAnimal")
                .Include("Raca")
                .Include("Raca.TipoAnimal")
                .ToList();
        }

        public IQueryable<CadastroAnimal>? Where(Expression<Func<CadastroAnimal, bool>> func)
        {
            return _Db.CadastroAnimal.Where(func)
                .Include("RFID")
                .Include("TipoAnimal")
                .Include("Raca")
                .Include("Raca.TipoAnimal");
        }

        public void SaveChanges()
        {
            _Db.SaveChanges();
        }
    }
}

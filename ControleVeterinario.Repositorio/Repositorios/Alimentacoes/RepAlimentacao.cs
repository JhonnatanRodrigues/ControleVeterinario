using ControleVeterinario.Dominio.Alimentacoes;
using ControleVeterinario.Dominio.ControleVeterinarios;
using ControleVeterinario.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ControleVeterinario.Repositorio.Repositorios.Alimentacoes
{
    public class RepAlimentacao : IRepAlimentacao
    {
        public readonly ContextoBanco _Db;

        public RepAlimentacao(ContextoBanco db)
        {
            _Db = db;
        }
        public async Task Inserir(Alimentacao alimentacao)
        {
            try
            {
                await _Db.Alimentacao.AddAsync(alimentacao);
                _Db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Alimentacao>? Listar()
        {
            return _Db.Alimentacao
                .Include("Animal")
                .Include("Animal.RFID")
                .Include("Animal.TipoAnimal")
                .Include("Animal.Raca")
                .ToList();
        }

        public IQueryable<Alimentacao>? Where(Expression<Func<Alimentacao, bool>> func)
        {
            return _Db.Alimentacao.Where(func);
        }

        public void SaveChanges()
        {
            _Db.SaveChanges();
        }
    }
}

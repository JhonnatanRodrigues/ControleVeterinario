using ControleVeterinario.Dominio.Alimentacoes;
using ControleVeterinario.Dominio.Vacinacoes;
using ControleVeterinario.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ControleVeterinario.Repositorio.Repositorios.Vacinacoes
{
    public class RepVacinacao : IRepVacinacao
    {
        public readonly ContextoBanco _Db;

        public RepVacinacao(ContextoBanco db)
        {
            _Db = db;
        }

        public async Task Inserir(Vacinacao vacinacao)
        {
            try
            {
                await _Db.Vacinacao.AddAsync(vacinacao);
                _Db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Vacinacao>? Listar()
        {
            return _Db.Vacinacao
                .Include(p => p.RFID)
                .ToList();
        }

        public IQueryable<Vacinacao>? Where(Expression<Func<Vacinacao, bool>> func)
        {
            return _Db.Vacinacao.Where(func);
        }

        public void SaveChanges()
        {
            _Db.SaveChanges();
        }
    }
}

using ControleVeterinario.Dominio.RFIDs;
using ControleVeterinario.Dominio.TipoAnimais;
using ControleVeterinario.Repositorio.Contexto;
using System.Linq.Expressions;

namespace ControleVeterinario.Repositorio.Repositorios.RFIDs
{
    public class RepRFID : IRepRFID
    {
        public readonly ContextoBanco _Db;

        public RepRFID(ContextoBanco db)
        {
            _Db = db;
        }

        public async Task Inserir(RFID rfid)
        {
            try
            {
                await _Db.RFIDs.AddAsync(rfid);
                _Db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public RFID? LerRFID(string codigoRFID)
        {
            return _Db.RFIDs.Where(x => x.CodigoRFID == codigoRFID).FirstOrDefault();
        }

        public IQueryable<RFID>? Where(Expression<Func<RFID, bool>> func)
        {
            return _Db.RFIDs.Where(func);
        }
        public void SaveChanges()
        {
            _Db.SaveChanges();
        }
        public List<RFID>? Listar()
        {
            return _Db.RFIDs.ToList();
        }
    }
}

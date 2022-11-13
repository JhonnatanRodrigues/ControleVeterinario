using ControleVeterinario.Dominio.TipoAnimais;
using System.Linq.Expressions;

namespace ControleVeterinario.Dominio.RFIDs
{
    public interface IRepRFID
    {
        IQueryable<RFID>? Where(Expression<Func<RFID, bool>> func);
        Task Inserir(RFID rfid);
        RFID? LerRFID(string codigoRFID);
        void SaveChanges();
        List<RFID>? Listar();
    }
}

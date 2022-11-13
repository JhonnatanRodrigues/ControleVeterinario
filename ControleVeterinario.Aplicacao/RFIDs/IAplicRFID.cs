using ControleVeterinario.Dominio.RFIDs;
using ControleVeterinario.Dominio.RFIDs.Dtos;

namespace ControleVeterinario.Aplicacao.RFIDs
{
    public interface IAplicRFID
    {
        void InserirNovoRFID(string codigoRFID);
        RFID LerRFID(string codigoRFID);
        void AlterarRfid(AlterarRfidDto dto);
        List<RFID> ListarRfids();
        void AtivarRFID(int codigoRFID);
        void DesativarRFID(int codigoRFID);
    }
}

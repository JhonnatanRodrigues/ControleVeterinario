using ControleVeterinario.Dominio.RFIDs;
using ControleVeterinario.Dominio.RFIDs.Dtos;
using System.Linq;

namespace ControleVeterinario.Aplicacao.RFIDs
{
    public class AplicRFID : IAplicRFID
    {
        private readonly IRepRFID _repRFID;

        public AplicRFID(IRepRFID repRFID)
        {
            _repRFID = repRFID;
        }

        public RFID LerRFID(string codigoRFID)
        {
            var rfid = _repRFID.LerRFID(codigoRFID);

            if(rfid == null)
                throw new Exception($"Código RFID: '{codigoRFID}' não foi encontrado.");

            return rfid;

        }

        public void InserirNovoRFID(string codigoRFID)
        {
            if (!codigoRFID.Any())
                throw new Exception("Não foi informado o codigo RFID.");
            var rfid = _repRFID.LerRFID(codigoRFID);
            if (rfid != null)
                throw new Exception($"RFID '{codigoRFID}', já foi cadastrado.");

            _repRFID.Inserir(new RFID
            {
                CodigoRFID = codigoRFID,
                DataCadastro = DateTime.Now
            });
        }

        public void AlterarRfid(AlterarRfidDto dto)
        {
            if (dto.CodigoRFID == null)
                throw new Exception("Não foi informado o código RFID.");

            var rfid = _repRFID.Where(x => x.CodigoRFID == dto.CodigoRFID && !x.Ativo).FirstOrDefault();

            if (rfid == null)
                throw new Exception("Não encontrado o código RFID.");

            rfid.EmUso = false;

            _repRFID.SaveChanges();
        }

        public void DesativarRFID(int codigoRFID)
        {
            if (codigoRFID == null)
                throw new Exception("Não foi informado o código RFID.");

            var rfid = _repRFID.Where(x => x.Id == codigoRFID).FirstOrDefault();

            if (rfid == null)
                throw new Exception($"Não foi encontrado RFID com o código {codigoRFID}.");

            rfid.Ativo = false;

            _repRFID.SaveChanges();
        }

        public void AtivarRFID(int codigoRFID)
        {
            if (codigoRFID == null)
                throw new Exception("Não foi informado o código RFID.");

            var rfid = _repRFID.Where(x => x.Id == codigoRFID).FirstOrDefault();

            if (rfid == null)
                throw new Exception($"Não foi encontrado RFID com o código {codigoRFID}.");

            var rfidAtivo = _repRFID.Where(x => x.CodigoRFID == rfid.CodigoRFID && x.Ativo).FirstOrDefault();

            if (rfidAtivo != null)
                throw new Exception($"Já tem um RFID do código {rfidAtivo.Id} ativo.");

            rfid.Ativo = true;

            _repRFID.SaveChanges();
        }

        public List<RFID> ListarRfids()
        {
            return _repRFID.Listar();
        }
    }
}

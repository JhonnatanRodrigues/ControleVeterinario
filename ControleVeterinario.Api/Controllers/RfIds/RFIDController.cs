using ControleVeterinario.Aplicacao.RFIDs;
using ControleVeterinario.Dominio.Mensageria;
using ControleVeterinario.Dominio.RFIDs.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ControleVeterinario.Api.Controllers.RfIds
{
    [ApiController]
    [Route("api/[controller]")]
    public class RFIDController : ControllerBase
    {
        private readonly IAplicRFID _aplicRFID;

        public RFIDController(IAplicRFID aplicRFID)
        {
            _aplicRFID = aplicRFID;
        }

        [HttpGet]
        [Route("LeitorRFID/{codigoRFID}")]
        public ResponseHttps LerRFID([FromRoute] string codigoRFID)
        {
            try
            {
                var ret = _aplicRFID.LerRFID(codigoRFID);

                return new ResponseHttps().RetSucesso(ret);
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError(ex.Message);
            }

        }

        [HttpPost]
        [Route("InserirNovoRFID")]
        public ResponseHttps InseririNovoRFID([FromBody] string codigoRFID)
        {
            try
            {
                _aplicRFID.InserirNovoRFID(codigoRFID);

                return new ResponseHttps().RetSucesso();
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("AlterarRfid")]
        public ResponseHttps AlterarRFID([FromBody] AlterarRfidDto dto)
        {
            try
            {
                _aplicRFID.AlterarRfid(dto);

                return new ResponseHttps().RetSucesso();
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError(ex.Message);
            }

        }

        [HttpGet]
        [Route("ListarRfids")]
        public ResponseHttps ListarRfids()
        {
            try
            {
                var ret = _aplicRFID.ListarRfids();

                return new ResponseHttps().RetSucesso(ret);
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError(ex.Message);
            }
        }

        [HttpPost]
        [Route("AtivarRfid")]
        public ResponseHttps AtivarRfid(int codigoRFID)
        {
            try
            {
                _aplicRFID.AtivarRFID(codigoRFID);

                return new ResponseHttps().RetSucesso("RFID Ativo.");
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError(ex.Message);
            }
        }

        [HttpPost]
        [Route("DesativarRFID")]
        public ResponseHttps DesativarRFID(int codigoRFID)
        {
            try
            {
                _aplicRFID.DesativarRFID(codigoRFID);

                return new ResponseHttps().RetSucesso("RFID Desativado.");
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError(ex.Message);
            }
        }
    }
}

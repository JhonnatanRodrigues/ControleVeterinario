using ControleVeterinario.Api.Controllers.MontadorMensagens;
using ControleVeterinario.Aplicacao.RFIDs;
using ControleVeterinario.Dominio.RFIDs.Dtos;
using FrozenForge.Apis;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ControleVeterinario.Api.Controllers.RfIds
{
    [ApiController]
    [Route("api/[controller]")]
    public class RFIDController : ControllerBase
    {
        private readonly IAplicRFID _aplicRFID;
        private readonly IMontarMSG _msg;

        public RFIDController(IAplicRFID aplicRFID, 
            IMontarMSG msg)
        {
            _aplicRFID = aplicRFID;
            _msg = msg;
        }

        [HttpGet]
        [Route("Leitor RFID/{codigoRFID}")]
        public ApiResponse LerRFID([FromRoute] string codigoRFID)
        {
            try
            {
                var ret = _aplicRFID.LerRFID(codigoRFID);

                return _msg.RetSucesso(ret);
            }
            catch (Exception ex)
            {
                return _msg.RetError(ex.Message);
            }

        }

        [HttpPost]
        [Route("Inserir Novo RFID")]
        public ApiResponse InseririNovoRFID([FromBody] string codigoRFID)
        {
            try
            {
                _aplicRFID.InserirNovoRFID(codigoRFID);

                return _msg.RetSucesso();
            }
            catch (Exception ex)
            {
                return _msg.RetError(ex.Message);
            }
            
        }

        [HttpPut]
        [Route("AlterarRfid")]
        public ApiResponse AlterarRFID([FromBody] AlterarRfidDto dto)
        {
            try
            {
                _aplicRFID.AlterarRfid(dto);

                return _msg.RetSucesso();
            }
            catch (Exception ex)
            {
                return _msg.RetError(ex.Message);
            }

        }

        [HttpGet]
        [Route("ListarRfids")]
        public ApiResponse ListarRfids()
        {
            try
            {
                var ret = _aplicRFID.ListarRfids();

                return _msg.RetSucesso(ret);
            }
            catch (Exception ex)
            {
                return _msg.RetError(ex.Message);
            }
        }

        [HttpPut]
        [Route("AtivarRfid")]
        public ApiResponse AtivarRfid(int codigoRFID)
        {
            try
            {
                _aplicRFID.AtivarRFID(codigoRFID);

                return _msg.RetSucesso("RFID Ativo.");
            }
            catch (Exception ex)
            {
                return _msg.RetError(ex.Message);
            }
        }

        [HttpPut]
        [Route("DesativarRFID")]
        public ApiResponse DesativarRFID(int codigoRFID)
        {
            try
            {
                _aplicRFID.DesativarRFID(codigoRFID);

                return _msg.RetSucesso("RFID Desativado.");
            }
            catch (Exception ex)
            {
                return _msg.RetError(ex.Message);
            }
        }
    }
}

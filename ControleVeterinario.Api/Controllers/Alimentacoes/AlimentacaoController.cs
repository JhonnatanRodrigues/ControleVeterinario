using ControleVeterinario.Api.Controllers.MontadorMensagens;
using ControleVeterinario.Aplicacao.Alimentacoes;
using FrozenForge.Apis;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ControleVeterinario.Api.Controllers.Alimentacoes
{
    [ApiController]
    [Route("api/Alimentacao")]
    public class AlimentacaoController : ControllerBase
    {
        private readonly IMontarMSG _msg;
        private readonly IAplicAlimentacao _aplicAlimentacao;

        public AlimentacaoController(IMontarMSG msg, IAplicAlimentacao aplicAlimentacao)
        {
            _msg = msg;
            _aplicAlimentacao = aplicAlimentacao;
        }

        [HttpPost]
        [Route("FoiAlimentar")]
        public ApiResponse FoiAlimentar([FromBody] string idRfid)
        {
            try
            {
                _aplicAlimentacao.FoiAlimentar(idRfid);

                return _msg.RetSucesso();
            }
            catch (Exception ex)
            {
                return _msg.RetError(ex.Message);
            }
        }

        [HttpPut]
        [Route("ParoAlimentar")]
        public ApiResponse ParoAlimentar([FromBody] string idRfid)
        {
            try
            {
                _aplicAlimentacao.ParoAlimentar(idRfid);

                return _msg.RetSucesso();
            }
            catch (Exception ex)
            {
                return _msg.RetError(ex.Message);
            }
        }

        [HttpGet]
        [Route("ListarAlimentacoes")]
        public ApiResponse ListarAlimentacoes()
        {
            try
            {
                var ret = _aplicAlimentacao.Listar();

                return _msg.RetSucesso(ret);
            }
            catch (Exception ex)
            {
                return _msg.RetError(ex.Message);
            }
        }
    }
}

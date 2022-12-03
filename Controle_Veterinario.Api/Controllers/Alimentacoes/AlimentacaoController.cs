using ControleVeterinario.Aplicacao.Alimentacoes;
using ControleVeterinario.Dominio.Mensageria;
using Microsoft.AspNetCore.Mvc;

namespace ControleVeterinario.Api.Controllers.Alimentacoes
{
    [ApiController]
    [Route("api/Alimentacao")]
    public class AlimentacaoController : ControllerBase
    {
        private readonly IAplicAlimentacao _aplicAlimentacao;

        public AlimentacaoController(IAplicAlimentacao aplicAlimentacao)
        {
            _aplicAlimentacao = aplicAlimentacao;
        }

        [HttpPost]
        [Route("FoiAlimentar")]
        public ResponseHttps FoiAlimentar([FromBody] string idRfid)
        {
            try
            {
                _aplicAlimentacao.FoiAlimentar(idRfid);

                return new ResponseHttps().RetSucesso();
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError(ex.Message);
            }
        }

        [HttpPost]
        [Route("ParoAlimentar")]
        public ResponseHttps ParoAlimentar([FromBody] string idRfid)
        {
            try
            {
                _aplicAlimentacao.ParoAlimentar(idRfid);

                return new ResponseHttps().RetSucesso();
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError(ex.Message);
            }
        }

        [HttpGet]
        [Route("ListarAlimentacoes")]
        public ResponseHttps ListarAlimentacoes()
        {
            try
            {
                var ret = _aplicAlimentacao.Listar();

                return new ResponseHttps().RetSucesso(ret);
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError(ex.Message);
            }
        }
    }
}

using ControleVeterinario.Aplicacao.Alimentacoes;
using ControleVeterinario.Aplicacao.Vacinacoes;
using ControleVeterinario.Dominio.Mensageria;
using ControleVeterinario.Dominio.Vacinacoes.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ControleVeterinario.Api.Controllers.Vacinacoes
{
    public class VacinacaoController : ControllerBase
    {
        private readonly IAplicVacinacao _aplicVacinacao;

        public VacinacaoController(IAplicVacinacao aplicVacinacao)
        {
            _aplicVacinacao = aplicVacinacao;
        }

        [HttpPost]
        [Route("Inserir")]
        public ResponseHttps Inserir([FromBody] NovaVacinacaoDto novaVacinacaoDto)
        {
            try
            {
                _aplicVacinacao.Inserir(novaVacinacaoDto);

                return new ResponseHttps().RetSucesso();
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError(ex.Message);
            }
        }

        [HttpPost]
        [Route("Aplicacao")]
        public ResponseHttps Aplicacao([FromBody] AplicVacinacaoDto aplicVacinacaoDto)
        {
            try
            {
                _aplicVacinacao.Aplicacao(aplicVacinacaoDto);

                return new ResponseHttps().RetSucesso();
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError(ex.Message);
            }
        }

        [HttpPost]
        [Route("Listar")]
        public ResponseHttps Listar()
        {
            try
            {
                var ret = _aplicVacinacao.Listar();

                return new ResponseHttps().RetSucesso(ret);
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError(ex.Message);
            }
        }
    }

}

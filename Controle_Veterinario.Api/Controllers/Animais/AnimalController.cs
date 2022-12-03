using ControleVeterinario.Aplicacao.Animais;
using ControleVeterinario.Aplicacao.Animais.Dtos;
using ControleVeterinario.Dominio.CadastroAnimais.Dto;
using ControleVeterinario.Dominio.Mensageria;
using ControleVeterinario.Dominio.TipoAnimais.Racas.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ControleVeterinario.Api.Controllers.Animais
{
    [ApiController]
    [Route("api/Animal")]
    public class AnimalController : ControllerBase
    {
        private readonly IAplicAnimal _aplicAnimal;

        public AnimalController(IAplicAnimal aplicAnimal)
        {
            _aplicAnimal = aplicAnimal;
        }

        [HttpPost]
        [Route("CadastrarEspecie")]
        public ResponseHttps CadastrarEspecie([FromBody] string nomeEspecie)
        {
            try
            {
                _aplicAnimal.CadastrarEspecie(nomeEspecie);

                return new ResponseHttps().RetSucesso();
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError($"Não foi possível cadastrar a espécie '{nomeEspecie}': {ex.Message}");
            }
        }

        [HttpGet]
        [Route("ListarEspecies")]
        public ResponseHttps ListarEspecies()
        {
            try
            {
                var ret = _aplicAnimal.ListarEspecies();
                return new ResponseHttps().RetSucesso(ret);
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError($"Erro ao listar espécies: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("BuscarEspecie/{id}/{especie}")]
        public ResponseHttps BuscarEspecie([FromRoute] int id, [FromRoute] string especie)
        {
            try
            {
                var dto = new FiltroEspeciesDto { Especie = especie, CodigoEspecie = id };
                var ret = _aplicAnimal.BuscarEspecie(dto);
                return new ResponseHttps().RetSucesso(ret);
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError($"Erro ao buscar espécie: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("CadastrarRaca")]
        public ResponseHttps CadastrarRaca([FromBody] CadRacaAnimalDto dto)
        {
            try
            {
                _aplicAnimal.CadastroRaca(dto);
                return new ResponseHttps().RetSucesso();
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError($"Não foi possível cadastrar: {ex.Message}");
            }
        }
        
        [HttpGet]
        [Route("ListarRacas")]
        public ResponseHttps ListarRacas()
        {
            try
            {
                var ret = _aplicAnimal.ListarRacas();
                return new ResponseHttps().RetSucesso(ret);
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError($"Erro ao listar raças: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("CadastrarAnimais")]
        public ResponseHttps CadastrarAnimais([FromBody] CadAnimalDto dto)
        {
            try
            {
                _aplicAnimal.CadastrarAnimal(dto);
                return new ResponseHttps().RetSucesso();
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError($"Não foi possível cadastrar: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("ListarAnimais")]
        public ResponseHttps ListarAnimais()
        {
            try
            {
                var ret = _aplicAnimal.ListarAnimais();
                return new ResponseHttps().RetSucesso(ret);
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError($"Erro ao listar animais: {ex.Message}");
            }
        }
    }
}

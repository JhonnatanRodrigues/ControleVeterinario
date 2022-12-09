using ControleVeterinario.Aplicacao.Animais;
using ControleVeterinario.Dominio.CadastroAnimais.Dto;
using ControleVeterinario.Dominio.Mensageria;
using ControleVeterinario.Dominio.TipoAnimais.Dto;
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

        #region Especie
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
        [Route("BuscarEspecie/{id}")]
        public ResponseHttps BuscarEspecie([FromRoute] int id)
        {
            try
            {
                var ret = _aplicAnimal.BuscarEspecie(id);
                return new ResponseHttps().RetSucesso(ret);
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError($"Erro ao buscar espécie: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("EditarEspecie")]
        public ResponseHttps EditarEspecie([FromBody] EspecieDto especie)
        {
            try
            {
                _aplicAnimal.AlterarEspecie(especie);
                return new ResponseHttps().RetSucesso();
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError($"Erro ao buscar espécie: {ex.Message}");
            }
        }
        #endregion

        #region Raca
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

        [HttpGet]
        [Route("BuscarRaca/{id}")]
        public ResponseHttps BuscarRaca([FromRoute] int id)
        {
            try
            {
                var ret = _aplicAnimal.BuscarRaca(id);
                return new ResponseHttps().RetSucesso(ret);
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError($"Erro ao buscar animal: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("EditarRaca")]
        public ResponseHttps EditarRaca([FromBody] RacaDto racaDto)
        {
            try
            {
                _aplicAnimal.AlterarRaca(racaDto);
                return new ResponseHttps().RetSucesso();
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError($"Erro ao buscar espécie: {ex.Message}");
            }
        }
        #endregion

        #region Animal
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

        [HttpGet]
        [Route("BuscarAnimal/{id}")]
        public ResponseHttps BuscarAnimal([FromRoute] int id)
        {
            try
            {
                var ret = _aplicAnimal.BuscarAnimal(id);
                return new ResponseHttps().RetSucesso(ret);
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError($"Erro ao buscar animal: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("EditarAnimal")]
        public ResponseHttps EditarAnimal([FromBody] AnimalDto animalDto)
        {
            try
            {
                _aplicAnimal.AlterarAnimal(animalDto);
                return new ResponseHttps().RetSucesso();
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetError(ex.Message);
            }
        }
        #endregion
    }
}

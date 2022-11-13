using ControleVeterinario.Api.Controllers.MontadorMensagens;
using ControleVeterinario.Aplicacao.Animais;
using ControleVeterinario.Aplicacao.Animais.Dtos;
using ControleVeterinario.Dominio.CadastroAnimais.Dto;
using ControleVeterinario.Dominio.TipoAnimais.Racas.Dtos;
using FrozenForge.Apis;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ControleVeterinario.Api.Controllers.Animais
{
    [ApiController]
    [Route("api/Animal")]
    public class AnimalController : ControllerBase
    {
        private readonly IMontarMSG _msg;
        private readonly IAplicAnimal _aplicAnimal;

        public AnimalController(IMontarMSG msg, 
            IAplicAnimal aplicAnimal)
        {
            _msg = msg;
            _aplicAnimal = aplicAnimal;
        }

        [HttpPost]
        [Route("CadastrarEspecie")]
        public ApiResponse CadastrarEspecie([FromBody] string nomeEspecie)
        {
            try
            {
                _aplicAnimal.CadastrarEspecie(nomeEspecie);
                return _msg.RetSucesso();
            }
            catch (Exception ex)
            {
                return _msg.RetError($"Não foi possível cadastrar a espécie '{nomeEspecie}': {ex.Message}");
            }
        }

        [HttpGet]
        [Route("ListarEspecies")]
        public ApiResponse ListarEspecies()
        {
            try
            {
                var ret = _aplicAnimal.ListarEspecies();
                return _msg.RetSucesso(ret);
            }
            catch (Exception ex)
            {
                return _msg.RetError($"Erro ao listar espécies: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("BuscarEspecie/{id}/{especie}")]
        public ApiResponse BuscarEspecie([FromRoute] int id, [FromRoute] string especie)
        {
            try
            {
                var dto = new FiltroEspeciesDto { Especie = especie, CodigoEspecie = id };
                var ret = _aplicAnimal.BuscarEspecie(dto);
                return _msg.RetSucesso(ret);
            }
            catch (Exception ex)
            {
                return _msg.RetError($"Erro ao buscar espécie: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("CadastrarRaca")]
        public ApiResponse CadastrarRaca([FromBody] CadRacaAnimalDto dto)
        {
            try
            {
                _aplicAnimal.CadastroRaca(dto);
                return _msg.RetSucesso();
            }
            catch (Exception ex)
            {
                return _msg.RetError($"Não foi possível cadastrar: {ex.Message}");
            }
        }
        
        [HttpGet]
        [Route("ListarRacas")]
        public ApiResponse ListarRacas()
        {
            try
            {
                var ret = _aplicAnimal.ListarRacas();
                return _msg.RetSucesso(ret);
            }
            catch (Exception ex)
            {
                return _msg.RetError($"Erro ao listar raças: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("CadastrarAnimais")]
        public ApiResponse CadastrarAnimais([FromBody] CadAnimalDto dto)
        {
            try
            {
                _aplicAnimal.CadastrarAnimal(dto);
                return _msg.RetSucesso();
            }
            catch (Exception ex)
            {
                return _msg.RetError($"Não foi possível cadastrar: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("ListarAnimais")]
        public ApiResponse ListarAnimais()
        {
            try
            {
                var ret = _aplicAnimal.ListarAnimais();
                return _msg.RetSucesso(ret);
            }
            catch (Exception ex)
            {
                return _msg.RetError($"Erro ao listar animais: {ex.Message}");
            }
        }
    }
}

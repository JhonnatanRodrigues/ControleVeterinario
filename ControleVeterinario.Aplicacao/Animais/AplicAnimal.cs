using ControleVeterinario.Dominio.CadastroAnimais.Dto;
using ControleVeterinario.Dominio.CadastroAnimais.Validacoes;
using ControleVeterinario.Dominio.ControleVeterinarios;
using ControleVeterinario.Dominio.RFIDs;
using ControleVeterinario.Dominio.TipoAnimais;
using ControleVeterinario.Dominio.TipoAnimais.Dto;
using ControleVeterinario.Dominio.TipoAnimais.Racas;
using ControleVeterinario.Dominio.TipoAnimais.Racas.Dtos;

namespace ControleVeterinario.Aplicacao.Animais
{
    public class AplicAnimal : IAplicAnimal
    {
        private readonly IRepTipoAnimal _repTipoAnimal;
        private readonly IRepRaca _repRaca;
        private readonly IRepRFID _repRFID;
        private readonly IRepCadastroAnimal _repCadastroAnimal;

        public AplicAnimal(IRepTipoAnimal repTipoAnimal,
            IRepRaca repRaca,
            IRepRFID repRFID,
            IRepCadastroAnimal repCadastroAnimal)
        {
            _repTipoAnimal = repTipoAnimal;
            _repRaca = repRaca;
            _repRFID = repRFID;
            _repCadastroAnimal = repCadastroAnimal;
        }

        public void AlterarRaca(RacaDto racaDto)
        {
            try
            {
                var raca = _repRaca.Where(x => x.Id == racaDto.Id).FirstOrDefault();

                if (raca == null)
                    throw new Exception($"Raça do código: '{racaDto.Id}', não encontrado.");

                var especie = _repTipoAnimal.Where(x => x.Id == racaDto.CodigoTipoAnimal).FirstOrDefault();

                if (especie == null)
                    throw new Exception($"Espécie do código: '{racaDto.CodigoTipoAnimal}', não encontrado.");

                raca.CodigoTipoAnimal = racaDto.CodigoTipoAnimal;
                raca.Raca = racaDto.Raca;
                raca.TipoAnimal = especie;

                _repRaca.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AlterarEspecie(EspecieDto especieDto)
        {
            try
            {
                var especie = _repTipoAnimal.Where(x => x.Id == especieDto.Id).FirstOrDefault();

                if(especie == null)
                    throw new Exception($"Espécie do código: '{especieDto.Id}', não encontrado.");

                especie.Tipo = especieDto.Tipo;

                _repTipoAnimal.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RacaAnimal BuscarRaca(int id)
        {
            try
            {
                var raca = _repRaca.Where(x => x.Id == id).FirstOrDefault();

                if (raca == null)
                    throw new Exception($"Raça do código: '{id}', não encontrada.");

                return raca;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public TipoAnimal BuscarEspecie(int id)
        {
            try
            {
                var especie = _repTipoAnimal.Where(x => x.Id == id).FirstOrDefault();

                if (especie == null)
                    throw new Exception($"Espécie do código: '{id}', não encontrado.");

                return especie;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void CadastroRaca(CadRacaAnimalDto dto)
        {
            if (dto == null || dto.Raca == null || dto.CodigoTipoAnimal == 0)
                throw new Exception("Não foi enformado todos os campos necessários para cadastrar a raça do animal.");

            var tipoAnimal = _repTipoAnimal.Where(p => p.Id == dto.CodigoTipoAnimal).ToList();

            if (tipoAnimal == null || tipoAnimal.Count == 0)
                throw new Exception($"Não foi encontrado a raça de código '{dto.CodigoTipoAnimal}'.");

            _repRaca.Inserir(new RacaAnimal
            {
                CodigoTipoAnimal = dto.CodigoTipoAnimal,
                Raca = dto.Raca,
                TipoAnimal = tipoAnimal.FirstOrDefault()
            });
            
        }

        public void CadastrarEspecie(string nomeEspecie)
        {
            if (nomeEspecie == null || !nomeEspecie.Any())
                throw new Exception("Não foi informado a espécie do anímal.");

            var especies = _repTipoAnimal.Where(x => x.Tipo == nomeEspecie).ToList();
            if (especies == null || especies.Count != 0)
                throw new Exception("Espécie já foi cadastrada.");

            var tipoAnimal = new TipoAnimal
            {
                Tipo = nomeEspecie
            };

            _repTipoAnimal.Inserir(tipoAnimal);
        }

        public List<RacaAnimal> ListarRacas()
        {
            return _repRaca.Listar();
        }

        public List<TipoAnimal> ListarEspecies()
        {
            return _repTipoAnimal.Listar();
        }

        public void CadastrarAnimal(CadAnimalDto dto)
        {
            var rfid = new RFID();
            var tipoAnimal = new TipoAnimal();
            var raca = new RacaAnimal();

            if (dto.CodigoRfId != null || dto.CodigoRfId != 0)
                rfid = _repRFID.Where(p => p.Id == dto.CodigoRfId && p.Ativo).FirstOrDefault();

            if (dto.CodigoTipoAnimal != null || dto.CodigoTipoAnimal != 0)
                tipoAnimal = _repTipoAnimal.Where(p => p.Id == dto.CodigoTipoAnimal).FirstOrDefault();

            if (dto.CodigoRaca != null || dto.CodigoRaca != 0)
                raca = _repRaca.Where(p => p.Id == dto.CodigoRaca).FirstOrDefault();


            var animal = new CadastroAnimal
            {
                CodigoRfId = dto.CodigoRfId,
                CodigoTipoAnimal = dto.CodigoTipoAnimal,
                CodigoRaca = dto.CodigoRaca,
                DataNacimento = dto.DataNacimento,
                Peso = dto.Peso,
                Genero = dto.Genero,
                TipoAnimal = tipoAnimal,
                Raca = raca,
                RFID = rfid
            };

            new ValidaAnimais().Valida(animal);

            _repCadastroAnimal.Inserir(animal);

            animal.RFID.EmUso = true;

            _repRFID.SaveChanges();
        }

        public List<CadastroAnimal> ListarAnimais()
        {
            return _repCadastroAnimal.Listar();
        }

        public CadastroAnimal BuscarAnimal(int id)
        {
            try
            {
                var animal = _repCadastroAnimal.Where(x => x.Id == id).FirstOrDefault();

                if (animal == null)
                    throw new Exception($"Animal do código: '{id}', não encontrado.");

                return animal;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void AlterarAnimal(AnimalDto animalDto)
        {
            try
            {
                var animal = _repCadastroAnimal.Where(x => x.Id == animalDto.Id).FirstOrDefault();

                if (animal == null)
                    throw new Exception($"Animal do código: '{animalDto.Id}', não encontrado.");

                animal.Mapear(animalDto);

                _repCadastroAnimal.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

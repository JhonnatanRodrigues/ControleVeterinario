using ControleVeterinario.Aplicacao.Animais.Dtos;
using ControleVeterinario.Dominio.CadastroAnimais.Dto;
using ControleVeterinario.Dominio.CadastroAnimais.Validacoes;
using ControleVeterinario.Dominio.ControleVeterinarios;
using ControleVeterinario.Dominio.RFIDs;
using ControleVeterinario.Dominio.TipoAnimais;
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

        public void AlterarRaca(CadRacaAnimalDto dto)
        {
            throw new NotImplementedException();
        }

        public void AlterarEspecie(string nomeEspecie)
        {
            throw new NotImplementedException();
        }

        public RacaAnimal BuscarRaca(int id)
        {
            throw new NotImplementedException();
        }

        public TipoAnimal BuscarEspecie(FiltroEspeciesDto dto)
        {
            if (dto.CodigoEspecie == null && dto.Especie == null)
                throw new Exception("Não foi informado o filtro da espécie.");

            return _repTipoAnimal.Where(p => (dto.CodigoEspecie != null && dto.CodigoEspecie != 0)
                                                ? p.Id == dto.CodigoEspecie
                                                : p.Tipo == dto.Especie).FirstOrDefault();
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
    }
}

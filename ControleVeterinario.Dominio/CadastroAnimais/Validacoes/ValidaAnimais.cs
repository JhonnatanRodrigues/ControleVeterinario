using ControleVeterinario.Dominio.ControleVeterinarios;
using ControleVeterinario.Dominio.RFIDs;
using ControleVeterinario.Dominio.TipoAnimais;
using ControleVeterinario.Dominio.TipoAnimais.Racas;

namespace ControleVeterinario.Dominio.CadastroAnimais.Validacoes
{
    public class ValidaAnimais
    {
        public void Valida(CadastroAnimal animal)
        {
            VerificaSeFoiInformadoTodosOsCamposObrigatorios(animal);
            VerificaRfidEmUso(animal.RFID);
            VerificarTipoAnimalERaca(animal.TipoAnimal, animal.Raca);
        }
        public void VerificaSeFoiInformadoTodosOsCamposObrigatorios(CadastroAnimal animal)
        {
            if (animal == null)
                throw new Exception("Não foi informado o animal a ser cadastrado.");

            if (animal.CodigoRfId == null || animal.CodigoRfId == 0)
                throw new Exception("Não foi informado o código RFID do animal.");

            if (animal.CodigoTipoAnimal == null || animal.CodigoTipoAnimal== 0)
                throw new Exception("Não foi informado a espécie do animal.");

            if (animal.CodigoRaca == null || animal.CodigoRaca == 0)
                throw new Exception("Não foi informado a raça do animal.");

            if (animal.Peso == null || animal.Peso == 0)
                throw new Exception("Não foi informado o peso RFID do animal.");

            if (animal.Genero == null)
                throw new Exception("Não foi informado o gênero do animal.");
        }
        public void VerificaRfidEmUso(RFID rfid)
        {
            if (rfid == null)
                throw new Exception("Animal está sem RFID");

            if (rfid.EmUso)
                throw new Exception($"RFID '{rfid.CodigoRFID}', já está em uso.");

        }
        public void VerificarTipoAnimalERaca(TipoAnimal especie, RacaAnimal racaAnimal)
        {
            if (especie == null)
                throw new Exception("Não foi informado a espécie do animal.");
            
            if (racaAnimal == null)
                throw new Exception("Não foi informado a raça do animal.");

            if (racaAnimal.CodigoTipoAnimal != especie.Id)
                throw new Exception($"A raça '{racaAnimal.Raca}', não faz parte da espécie '{especie.Tipo}'.");



        }
    }
}

using ControleVeterinario.Dominio.CadastroAnimais.Dto;
using ControleVeterinario.Dominio.ControleVeterinarios;
using ControleVeterinario.Dominio.TipoAnimais;
using ControleVeterinario.Dominio.TipoAnimais.Dto;
using ControleVeterinario.Dominio.TipoAnimais.Racas;
using ControleVeterinario.Dominio.TipoAnimais.Racas.Dtos;

namespace ControleVeterinario.Aplicacao.Animais
{
    public interface IAplicAnimal
    {
        void CadastrarEspecie(string nomeEspecie);
        void AlterarEspecie(EspecieDto especie);
        List<TipoAnimal> ListarEspecies();
        TipoAnimal BuscarEspecie(int id);

        void CadastroRaca(CadRacaAnimalDto dto);
        void AlterarRaca(RacaDto racaDto);
        List<RacaAnimal> ListarRacas();
        RacaAnimal BuscarRaca(int id);

        void CadastrarAnimal(CadAnimalDto dto);
        List<CadastroAnimal> ListarAnimais();
        CadastroAnimal BuscarAnimal(int id);
        void AlterarAnimal(AnimalDto animalDto);
    }
}

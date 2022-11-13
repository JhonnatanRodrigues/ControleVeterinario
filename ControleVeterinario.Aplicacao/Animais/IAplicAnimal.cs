using ControleVeterinario.Aplicacao.Animais.Dtos;
using ControleVeterinario.Dominio.CadastroAnimais.Dto;
using ControleVeterinario.Dominio.ControleVeterinarios;
using ControleVeterinario.Dominio.TipoAnimais;
using ControleVeterinario.Dominio.TipoAnimais.Racas;
using ControleVeterinario.Dominio.TipoAnimais.Racas.Dtos;

namespace ControleVeterinario.Aplicacao.Animais
{
    public interface IAplicAnimal
    {
        void CadastrarEspecie(string nomeEspecie);
        void AlterarEspecie(string nomeEspecie);
        List<TipoAnimal> ListarEspecies();
        TipoAnimal BuscarEspecie(FiltroEspeciesDto dto);

        void CadastroRaca(CadRacaAnimalDto dto);
        void AlterarRaca(CadRacaAnimalDto dto);
        List<RacaAnimal> ListarRacas();
        RacaAnimal BuscarRaca(int id);

        void CadastrarAnimal(CadAnimalDto dto);
        List<CadastroAnimal> ListarAnimais();
    }
}

using ControleVeterinario.Dominio.Alimentacoes;
using ControleVeterinario.Repositorio.Contexto;

namespace ControleVeterinario.Repositorio.Repositorios.Alimentacoes
{
    public class RepAlimentacao : IRepAlimentacao
    {
        public readonly ContextoBanco _Db;

        public RepAlimentacao(ContextoBanco db)
        {
            _Db = db;
        }
    }
}

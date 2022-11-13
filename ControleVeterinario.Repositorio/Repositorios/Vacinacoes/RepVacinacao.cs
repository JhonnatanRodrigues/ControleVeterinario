using ControleVeterinario.Dominio.Vacinacoes;
using ControleVeterinario.Repositorio.Contexto;

namespace ControleVeterinario.Repositorio.Repositorios.Vacinacoes
{
    public class RepVacinacao : IRepVacinacao
    {
        public readonly ContextoBanco _Db;

        public RepVacinacao(ContextoBanco db)
        {
            _Db = db;
        }
    }
}

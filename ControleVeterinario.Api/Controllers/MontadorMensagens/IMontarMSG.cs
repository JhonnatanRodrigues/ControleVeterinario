using FrozenForge.Apis;

namespace ControleVeterinario.Api.Controllers.MontadorMensagens
{
    public interface IMontarMSG
    {
        ApiResponse RetSucesso();
        ApiResponse RetSucesso(object content);
        ApiResponse RetSucesso(object content, string? msg);
        ApiResponse RetAlerta(string? msg);
        ApiResponse RetAlerta(string? msg, object content);
        ApiResponse RetError(string? msg);
    }
}

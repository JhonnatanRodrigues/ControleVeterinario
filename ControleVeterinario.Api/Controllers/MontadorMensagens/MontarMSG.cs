using FrozenForge.Apis;
using System.Net;

namespace ControleVeterinario.Api.Controllers.MontadorMensagens
{
    public class MontarMSG : IMontarMSG
    {
        public ApiResponse RetSucesso()
        {
            var ret = new ApiResponse();
            ret.StatusCode = HttpStatusCode.OK;
            
            return ret;
        }
        public ApiResponse RetSucesso(object content)
        {
            var ret = new ApiResponse();

            ret.StatusCode = HttpStatusCode.OK;
            ret.Body = content;

            return ret;
        }

        public ApiResponse RetSucesso(object content, string? msg)
        {
            var ret = new ApiResponse();

            ret.StatusCode = HttpStatusCode.OK;
            ret.Body = content;
            ret.ReasonPhrase = msg;

            return ret;
        }

        public ApiResponse RetAlerta(string? msg)
        {
            var ret = new ApiResponse();

            ret.StatusCode = HttpStatusCode.FailedDependency;
            ret.ReasonPhrase = msg;

            return ret;
        }

        public ApiResponse RetAlerta(string? msg, object content)
        {
            var ret = new ApiResponse();

            ret.StatusCode = HttpStatusCode.FailedDependency;
            ret.ReasonPhrase = msg;
            ret.Body = content;

            return ret;
        }

        public ApiResponse RetError(string? msg)
        {
            var ret = new ApiResponse();

            ret.StatusCode = HttpStatusCode.ExpectationFailed;
            ret.ReasonPhrase = msg;

            return ret;
        }

    }
}

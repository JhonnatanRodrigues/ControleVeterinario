using FrozenForge.Apis;
using System.Net;

namespace ControleVeterinario.Dominio.Mensageria
{
    public class ResponseHttps : ApiResponse
    {
        public bool Success { get; set; }

        public ResponseHttps RetSucesso()
        {
            StatusCode = HttpStatusCode.OK;
            Success = true;
            return this;
        }

        public ResponseHttps RetSucesso(object content)
        {
            StatusCode = HttpStatusCode.OK;
            Body = content;
            Success = true;
            return this;
        }

        public ResponseHttps RetSucesso(object content, string? msg)
        {
            StatusCode = HttpStatusCode.OK;
            Body = content;
            ReasonPhrase = msg;
            Success = true;
            return this;
        }

        public ResponseHttps RetAlerta(string? msg)
        {
            StatusCode = HttpStatusCode.FailedDependency;
            ReasonPhrase = msg;
            Success = false;
            return this;
        }

        public ResponseHttps RetAlerta(string? msg, object content)
        {
            StatusCode = HttpStatusCode.FailedDependency;
            ReasonPhrase = msg;
            Body = content;
            Success = false;
            return this;
        }

        public ResponseHttps RetError(string? msg)
        {
            StatusCode = HttpStatusCode.ExpectationFailed;
            ReasonPhrase = msg;
            Success = false;
            return this;
        }
    }
}

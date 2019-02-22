using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
using System.Net.Http;
using System.Text;
using Teste.Business.Base;

namespace Teste.Helper
{
    public static class ErrorHandle
    {
        public static HttpResponseMessage GetModelStateErrors(ModelStateDictionary modelState)
        {
            StringBuilder errors = new StringBuilder();

            foreach (var item in modelState)
            {
                foreach (var error in item.Value.Errors)
                {
                    errors.AppendLine(error.ErrorMessage);
                }
            }

            HttpResponseMessage httpErrorsMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(errors.ToString())
            };

            return httpErrorsMessage;
        }


        public static int StatusCodeApi(MessageType code)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            switch (code)
            {
                case MessageType.SUCCESS:
                    statusCode = HttpStatusCode.OK;
                    break;
                case MessageType.ERRO:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case MessageType.ERRORSERVER:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
                default:
                    break;
            }

            return (int)statusCode;
        }
    }
}

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Stefanini.ApiRest.Controllers.Base;
using Stefanini.Domain.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Stefanini.ApiRest.MiddleWare
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleException(context, e);
            }
        }

        private static Task HandleException(HttpContext context, Exception exception)
        {
            HttpStatusCode code;
            object response = new BaseResultModel { Success = false, Message = exception.Message, Result = null };

            switch (exception)
            {
                case TokenException _:
                    code = HttpStatusCode.Forbidden;
                    break;
                case UserException _:
                    code = HttpStatusCode.BadRequest;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response,
                new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
                    Formatting = Formatting.Indented
                }));
        }
    }
}

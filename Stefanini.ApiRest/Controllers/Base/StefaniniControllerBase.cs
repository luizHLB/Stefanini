using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Stefanini.ApiRest.Controllers.Base
{
    public class StefaniniControllerBase : ControllerBase
    {
        public static ActionResult GetResponse<T>(T data, bool sucess = true, string message = "Operation Completed", int statusCode = StatusCodes.Status200OK)
        {
            var valueResult = new object();
            var valueFromResult = new object();

            if (data?.GetType()?.GetProperties()?.Any(p => p.Name == "Result") == true)
            {
                valueFromResult = data.GetType().GetProperty("Result").GetValue(data);
            }
            else
            {
                valueFromResult = data;
            }

            switch (statusCode)
            {
                case StatusCodes.Status200OK:
                case StatusCodes.Status400BadRequest:
                    valueResult = new BaseResultModel
                    {
                        Success = sucess,
                        Notifications = message,
                        Result = valueFromResult
                    };
                    break;

                case StatusCodes.Status500InternalServerError:
                    throw new Exception(message);
            }


            var result = new ObjectResult(valueResult)
            {
                StatusCode = statusCode
            };

            return result;
        }
    }

    public class BaseResultModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Notifications { get; set; }
        public object Result { get; set; }
    }
}

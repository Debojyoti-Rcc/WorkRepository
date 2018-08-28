using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Bot.Connector;
using System.Net;

namespace Microservice_Test.Filters
{
    public class ErrorHandlingFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            HandleExceptionAsync(context);
            context.ExceptionHandled = true;
        }

        private static void HandleExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;

            if(exception is DivideByZeroException)
                SetExceptionResult(context, exception, HttpStatusCode.NotFound);

            //if (exception is MyNotFoundException)
            //    SetExceptionResult(context, exception, HttpStatusCode.NotFound);
            //else if (exception is MyUnauthorizedException)
            //    SetExceptionResult(context, exception, HttpStatusCode.Unauthorized);
            //else if (exception is MyException)
            //    SetExceptionResult(context, exception, HttpStatusCode.BadRequest);
            else
                SetExceptionResult(context, exception, HttpStatusCode.InternalServerError);
        }

        private static void SetExceptionResult(ExceptionContext context,Exception exception,  HttpStatusCode code)
        {
            //var result = JsonConvert.SerializeObject(new { error = exception.Message });
            //context.Response.ContentType = "application/json";
            //context.Response.StatusCode = (int)code;
            //return context.Response.WriteAsync(result);
            context.Result = new JsonResult(new APIResponse(exception.Message))
            {
                StatusCode = (int)code
            };
        }
    }
}

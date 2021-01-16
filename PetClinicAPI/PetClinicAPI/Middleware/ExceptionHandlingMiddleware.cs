using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace PetClinicAPI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
                _logger.LogInformation("asdasdasdasdadsa");
            }
            catch (Exception e)
            {
               _logger.LogError(e, e.Message);
               await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            if (exception is UnauthorizedAccessException)
            {
                status = HttpStatusCode.Unauthorized;
            }
            else if (exception is NotImplementedException)
            {
                status = HttpStatusCode.NotImplemented;
            }

            context.Response.StatusCode = (int)status;
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(exception.Message);
        }
    }
}

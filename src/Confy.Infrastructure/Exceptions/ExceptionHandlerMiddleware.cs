using Confy.Infrastructure.Exceptions.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Confy.Infrastructure.Exceptions
{
    internal class ExceptionHandlerMiddleware(
        IExceptionToErrorMapper exceptionMapper,
        ILogger<ExceptionHandlerMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception exception)
            {
               await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            logger.LogError(exception, "Exception {Method} {Path}",
                context.Request.Method, context.Request.Path);

            var error = exceptionMapper.Map(exception);
            var errorTxt = JsonConvert.SerializeObject(error);

            context.Response.StatusCode = 400;
            await context.Response.WriteAsync(errorTxt);
        }
    }
}

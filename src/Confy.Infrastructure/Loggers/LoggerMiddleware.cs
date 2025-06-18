using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Confy.Infrastructure.Loggers
{
    internal sealed class LoggerMiddleware(
        ILogger<LoggerMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var request = context.Request;

            logger.LogInformation("➡️ HTTP {Method} {Path}", request.Method, request.Path);

            await next(context);

            var response = context.Response;
            logger.LogInformation("⬅️ HTTP {StatusCode} {Method} {Path}", response.StatusCode, request.Method, request.Path);
        }
    }
}

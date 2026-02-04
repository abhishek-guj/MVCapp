using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCapp.PL.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;
        public LoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _loggerFactory = loggerFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var logger = _loggerFactory.CreateLogger<LoggingMiddleware>();
            logger.LogInformation("{Path} at {time}", context.Request.Path, DateTime.Now);
            await _next(context);
            logger.LogInformation("{Path}: {StatusCode} at {time}", context.Request.Path, context.Response.StatusCode, DateTime.Now);
        }

    }
}
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace VMS.Middleware
{
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorLoggingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                // https://blog.dudak.me/2014/custom-middleware-with-dependency-injection-in-asp-net-core/
                var logger = (ILogger<ErrorLoggingMiddleware>)context.RequestServices.GetService(typeof(ILogger<ErrorLoggingMiddleware>));

                logger.LogError(exception, "Unhandled exception.");
                throw;
            }
        }
    }
}

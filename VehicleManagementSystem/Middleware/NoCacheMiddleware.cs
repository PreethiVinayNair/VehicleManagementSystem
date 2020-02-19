using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace VMS.Middleware
{
    public class NoCacheMiddleware
    {
        private readonly RequestDelegate next;

        public NoCacheMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            context.Response.Headers["Pragma"] = "no-cache";
            context.Response.Headers["Expires"] = "0";

            await next(context);
        }
    }
}
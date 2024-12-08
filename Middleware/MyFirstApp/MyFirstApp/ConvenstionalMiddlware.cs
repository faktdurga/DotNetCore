using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyFirstApp
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ConvenstionalMiddlware
    {
        private readonly RequestDelegate _next;

        public ConvenstionalMiddlware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task<Task> Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Query.ContainsKey("fname") && httpContext.Request.Query.ContainsKey("lname"))
            {
                string output = httpContext.Request.Query["fname"] + " " + httpContext.Request.Query["lname"];

                await httpContext.Response.WriteAsync("Hello " + output +"\n");
            }

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ConvenstionalMiddlwareExtensions
    {
        public static IApplicationBuilder UseConvenstionalMiddlware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConvenstionalMiddlware>();
        }
    }
}

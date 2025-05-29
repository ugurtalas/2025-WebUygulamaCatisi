using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MVC.Middlewares
{
    public class PerformanceMeterMiddleware
    {
        private readonly RequestDelegate _next;

        public PerformanceMeterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            //Console.WriteLine("Performance Meter Middleware çalıştı");
            //Console.WriteLine("Middleware ilk bölümü çalıştı");

            var Timer = Stopwatch.StartNew();
            await _next(httpContext);
            Timer.Stop();
           
            Console.WriteLine(httpContext.Request.Path +"  işlemi : " + Timer.ElapsedMilliseconds + " Milisaniye sürdü.");
            // Console.WriteLine("Middleware ikinci bölümü çalıştı");

            //Console.WriteLine("Performance Middleware Sonlandı");
        }
    }

    public static class PerformanceMeterMiddlewareExtensions
    {
        public static IApplicationBuilder UsePerformanceMeterMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PerformanceMeterMiddleware>();
        }
    }
}

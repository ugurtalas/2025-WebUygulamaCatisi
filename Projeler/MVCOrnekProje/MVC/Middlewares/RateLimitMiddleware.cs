using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace MVC.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RateLimitMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _period = TimeSpan.FromMinutes(1);


        public RateLimitMiddleware(RequestDelegate next,IMemoryCache memoryCache)
        {
            _next = next;
            _cache = memoryCache;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            //Console.WriteLine("RateLimit Middleware çalıştı");

           

            string ipAdress=  httpContext.Connection.RemoteIpAddress.ToString();

            var cacheKey = $"RateLimit_{ipAdress}";
            var Sayac = _cache.Get<int>(cacheKey);
            Sayac++;
            _cache.Set(cacheKey, Sayac,_period);
          
            if (Sayac > 80)
            {
                await httpContext.Response.WriteAsync(" İlgili kullanıcı limiti aştı");
                return;
            }

            //Console.WriteLine(Sayac);

            await _next(httpContext);

            //Console.WriteLine("RateLimit Middleware Sonlandı");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RateLimitMiddlewareExtensions
    {
        public static IApplicationBuilder UseRateLimitMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RateLimitMiddleware>();
        }
    }
}

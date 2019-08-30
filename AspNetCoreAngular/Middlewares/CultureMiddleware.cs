using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.Globalization;
using System.Threading.Tasks;

namespace AspNetCoreAngular.Middlewares
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var requestCultureFeature = context.Request.GetDisplayUrl().Split('/')[3];
            if (!string.IsNullOrWhiteSpace(requestCultureFeature))
            {
                var culture = new CultureInfo(requestCultureFeature);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }

            return _next(context);
        }
    }

    public static class CulturedMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CultureMiddleware>();
        }
    }
}

using AspNetCore.Infra.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}

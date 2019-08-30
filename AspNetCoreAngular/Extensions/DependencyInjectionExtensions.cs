using AspNetCoreAngular.Infra.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreAngular.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}

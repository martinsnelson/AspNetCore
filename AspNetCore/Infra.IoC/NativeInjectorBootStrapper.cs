using AspNetCore.Data;
using AspNetCore.Infra.Logs;
using AspNetCore.Interface.Repositories;
using AspNetCore.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AspNetCore.Infra.IoC
{
    public class NativeInjectorBootStrapper
    {
        private static  IConfiguration _configuration;

        public NativeInjectorBootStrapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ILogger<ActionLogger>, Logger<ActionLogger>>();
            services.AddScoped<ActionLogger>();

            //  Repositories
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();            

            services.AddAutoMapper();
        }
    }
}

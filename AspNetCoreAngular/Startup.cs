using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreAngular.Data;
using AspNetCoreAngular.Interface.Repositories;
using AspNetCoreAngular.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AspNetCoreAngular
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private readonly string CorsOrigins = "_CorsOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors();
            //  Context
            services.AddDbContext<AspNetCoreAngularContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SQLConnection")));
            //  Repositories
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();            

            // services.AddCors(options  =>
            // {
            //     options.AddPolicy(CorsOrigins, 
            //     builder =>
            //     {
            //         builder.WithOrigins("http://localhost:4200")
            //                             .AllowAnyHeader()
            //                             .AllowAnyMethod()
            //                             .AllowAnyOrigin()
            //                             .AllowCredentials();
                                     
            //         //.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
            //     });
            // });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                        .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddAutoMapper();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
            // app.UseCors(CorsOrigins);
            app.UseCors(options => options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthentication();
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

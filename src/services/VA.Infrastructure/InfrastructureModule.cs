using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetDevPack.Security.Jwt;
using NetDevPack.Security.Jwt.Store.EntityFrameworkCore;
using NetDevPack.Security.JwtExtensions;
using System;
using System.Net.Http;
using System.Reflection;
using VA.Infrastructure.Data;
using VA.Infrastructure.Data.Identity;
using VA.Infrastructure.PipelineBehaviours;

namespace VA.Infrastructure
{
    public static class InfrastructureModule
    {
        public static void AddInfrastructure(this IServiceCollection services) 
        {
            services
                .AddApplicationDbContext()
                .AddIdentity()
                .AddMediator()
                .AddJwt();
        }
        public static void UseInfrastructure(this IApplicationBuilder builder)
        {
            builder
                .UseAuthConfiguration();
        }

        private static IServiceCollection AddIdentity(this IServiceCollection services) 
        {
            services
                .AddIdentity<IdentityUser, IdentityRole>(
                    options => {
                        options.SignIn.RequireConfirmedAccount = false;
                        options.Password.RequireDigit = true;
                        options.Password.RequireLowercase = true;
                        options.Password.RequireNonAlphanumeric = true;
                        options.Password.RequireUppercase = true;
                        options.Password.RequiredLength = 6;
                        options.Password.RequiredUniqueChars = 1;
                    })
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddDefaultTokenProviders();

            services.AddMemoryCache();

            services
                .AddJwksManager(o =>
                {
                    o.Jws = JwsAlgorithm.ES256;
                    o.Jwe = JweAlgorithm.RsaOAEP.WithEncryption(Encryption.Aes128CbcHmacSha256);
                })
                .PersistKeysToDatabaseStore<ApplicationContext>();
            return services;
        }

        private static IServiceCollection AddApplicationDbContext(this IServiceCollection services)
        {
            services
               .AddDbContext<ApplicationContext>(
                    options => options
                       .UseSqlServer("Server=localhost,1433;Database=vagas_aqui;User ID=sa;Password=1q2w3e4r@#$", 
                        o => o.EnableRetryOnFailure())
                       .LogTo(Console.WriteLine, LogLevel.Information)
                       .EnableSensitiveDataLogging());

            services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationContext>());

            return services;
        }

        public static IServiceCollection AddJwt(this IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.BackchannelHttpHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = delegate { return true; } };
                x.SaveToken = true;
                x.SetJwksOptions(new JwkOptions("https://localhost:5001/jwks"));
            });

            return services;
        }
        public static IServiceCollection AddMediator(this IServiceCollection services) 
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

            return services;
        }

        public static IApplicationBuilder UseAuthConfiguration(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}

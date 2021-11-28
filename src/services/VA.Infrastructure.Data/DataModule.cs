using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetDevPack.Security.Jwt;
using NetDevPack.Security.Jwt.Store.EntityFrameworkCore;
using System;
using VA.Infrastructure.Data.Identity;

namespace VA.Infrastructure.Data
{
    public static class DataModule
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services)
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

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services)
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
    }
}

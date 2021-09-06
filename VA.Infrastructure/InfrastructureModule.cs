using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using VA.Infrastructure.Data;

namespace VA.Infrastructure
{
    public static class InfrastructureModule
    {
        public static void DependencyInjectionInfrastructure(this IServiceCollection services) 
        {
            services
                .AddDbContext<ApplicationContext>(
                     options => options
                        .UseSqlServer("Server=localhost,1433;Database=vagas_aqui;User ID=sa;Password=1q2w3e4r@#$")
                        .LogTo(Console.WriteLine, LogLevel.Information)
                        .EnableSensitiveDataLogging());

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
                .AddEntityFrameworkStores<ApplicationContext>();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VA.Application;
using VA.Infrastructure;

namespace VA.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddInfraCors()
                .AddInfraControllers()
                .AddInfraSwagger()
                .AddInfraVersioning()
                .AddApplicationDbContext()
                .AddIdentity()
                .AddMediator()
                .AddJwt()
                .AddApplication()
                .AddGlobalException();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app
               .UseCors("AllowAll")
               .UseGlobalException()
               .UseSwagger(env, provider)
               .UseRouting()
               .UseAuth()
               .UseEndpoints(opt => opt.MapControllers());
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VA.API.Data.Fabrica;
using VA.API.Data.Repositories.Empresa;
using VA.API.Services;

namespace VA.API
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
            services.AddCors(
               options => options.AddPolicy(
                   "AllowAll", p =>
                   {
                       p.AllowAnyOrigin();
                       p.AllowAnyMethod();
                       p.AllowAnyHeader();
                   }));

            services
                .AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);

            services
              .AddSwaggerGen(c =>
              {
                  c.SwaggerDoc("v1", new OpenApiInfo
                  {
                      Title = "API Vagas Aqui",
                      Description = "API  Vagas Aqui",
                      Contact = new OpenApiContact() { Name = "Vagas Aqui" },
                      Version = "v1"
                  });
              });

            services
                .AddScoped<IEmpresaServices, EmpresaServices>()
                .AddScoped<IEmpresaRepository, EmpresaRepository>()
                .AddSingleton<IConnectionFactory, ConnectionFactory>(); 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAll");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "API Vagas Aqui");
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetDevPack.Security.JwtExtensions;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using VA.Infrastructure.CrossCutting.Mediator.PipelineBehaviours;
using VA.Infrastructure.CrossCutting.Middleware;
using VA.Infrastructure.CrossCutting.PipelineBehaviours;
using VA.Infrastructure.CrossCutting.Swagger;


namespace VA.Infrastructure.CrossCutting
{
    public static class InfrastructureModule
    {
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
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FailFastValidation<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

            return services;
        }
        public static IServiceCollection AddInfraCors(this IServiceCollection services) 
        {
            services
               .AddCors(options => options.AddPolicy(
                  "AllowAll", p =>
                  {
                      p.AllowAnyOrigin();
                      p.AllowAnyMethod();
                      p.AllowAnyHeader();
                  }));

            return services;
        }
        public static IServiceCollection AddInfraControllers(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.IgnoreNullValues = true;
                    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(namingPolicy: JsonNamingPolicy.CamelCase));
                })
                .ConfigureApiBehaviorOptions(opt =>
                {
                    opt.ClientErrorMapping[StatusCodes.Status400BadRequest].Link = "https://httpstatuses.com/400";
                    opt.ClientErrorMapping[StatusCodes.Status401Unauthorized].Link = "https://httpstatuses.com/401";
                    opt.ClientErrorMapping[StatusCodes.Status403Forbidden].Link = "https://httpstatuses.com/403";
                    opt.ClientErrorMapping[StatusCodes.Status404NotFound].Link = "https://httpstatuses.com/404";
                    opt.ClientErrorMapping[StatusCodes.Status406NotAcceptable].Link = "https://httpstatuses.com/406";
                    opt.ClientErrorMapping[StatusCodes.Status500InternalServerError].Link = "https://httpstatuses.com/500";
                });

            return services;
        }
        public static IServiceCollection AddInfraSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();

            services.ConfigureOptions<ConfigureSwaggerOptions>();

            return services;
        }
        public static IServiceCollection AddInfraVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.UseApiBehavior = false;
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);

                o.ApiVersionReader = ApiVersionReader.Combine(
                    new HeaderApiVersionReader("x-api-version"),
                    new QueryStringApiVersionReader(),
                    new UrlSegmentApiVersionReader());
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }

        public static IApplicationBuilder UseAuth(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger(c =>
                {
                    c.SerializeAsV2 = true;
                });
                app.UseSwaggerUI(options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"../swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
            }

            return app;
        }
        public static IApplicationBuilder UseGlobalException(this IApplicationBuilder app)
        {
            app.UseMiddleware(typeof(ExceptionMiddleware));

            return app;
        }
    }
}

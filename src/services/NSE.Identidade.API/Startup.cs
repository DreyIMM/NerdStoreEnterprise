using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.Identidade.API.Configuration;


namespace NSE.Identidade.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }


        //Onde adicionamos os Midlewares ao pipelaine do ASP.NET
        public void ConfigureServices(IServiceCollection services)
        {
            //Configuração do Identity
            services.AddIdentityConfiguration(Configuration);

            //Configuração da Api
            services.AddApiConfiguration();

            //Configuração do Swagger
            services.AddSwaggerConfig();

            //Configuração do MessageBus
            services.AddMessageBusConfiguration(Configuration);
        }

        //Metodo que usa os middlerware no pipelaine
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerConfig();

            app.UseApiConfiguration(env);

        }
    }
}

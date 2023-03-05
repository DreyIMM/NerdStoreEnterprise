using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NSE.Identidade.API.Data;
using System;

namespace NSE.Identidade.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //Onde adicionamos os Midlewares ao pipelaine do ASP.NET
        public void ConfigureServices(IServiceCollection services)
        {
            //Configurando o DBContext para o Identity
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Configuração para o Suporte ao Identity
            services.AddDefaultIdentity<IdentityUser>()
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title= "NerdStore Enterprise Identity API",
                    Description = "Api de autenticação da loja NerdStore Enterprise Aplication",
                    Contact = new OpenApiContact() {Name = "andrey barbosa", Email = "andrey.barbosa@devq.com.br"},
                    License = new OpenApiLicense() { Name= "MIT", Url = new Uri("https://opensource.org/licenses/MIT")}
                });
            });
        }

        //Metodo que usa os middlerware no pipelaine
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

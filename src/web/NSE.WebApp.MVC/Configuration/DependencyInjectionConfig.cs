using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Services;
using NSE.WebApp.MVC.Services.Handlers;
using System;

namespace NSE.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {

        public static void RegisterServices (this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<HttpClientAuthorizationDelegationHandler>();

            services.AddHttpClient<IAutenticacaoServices, AutenticacaoServices>();

            //services.AddHttpClient<ICatalogoService, CatalogoService>()
            //    .AddHttpMessageHandler<HttpClientAuthorizationDelegationHandler>();

            //Trabalhando com a ideia do Refit
            services.AddHttpClient("Refit", 
                options =>
            {
                options.BaseAddress = new Uri(configuration.GetSection("CatalogoUrl").Value);
            })
                .AddHttpMessageHandler<HttpClientAuthorizationDelegationHandler>()
                .AddTypedClient(Refit.RestService.For<ICatalogoServiceRefit>);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();
        }

    }
}

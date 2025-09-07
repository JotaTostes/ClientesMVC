using Clientes.Domain.Interfaces;
using Clientes.Infra.Data.Repositories;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Clientes.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            //Services

            //Repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            services.AddScoped<ITipoTelefoneRepository, TipoTelefoneRepository>();

            return services;
        }
    }
}

using Clientes.Application.Interfaces;
using Clientes.Application.Services;
using Clientes.Domain.Interfaces;
using Clientes.Infra.Data;
using Clientes.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clientes.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjection(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //Context
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //Services
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ITelefoneService, TelefoneService>();

            //Repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            services.AddScoped<ITipoTelefoneRepository, TipoTelefoneRepository>();

            return services;
        }
    }
}

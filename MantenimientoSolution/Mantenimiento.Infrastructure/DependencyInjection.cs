namespace Mantenimiento.Infrastructure;

using Mantenimiento.Infrastructure.Persistence;
using Mantenimiento.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
         // 1. Registrar el AppDbContext con SQL Server
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // 2. Registrar IAppDbContext para que se pueda inyectar en los casos de uso
        services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

        return services;
    }
}
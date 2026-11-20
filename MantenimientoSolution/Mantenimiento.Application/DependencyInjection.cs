namespace Mantenimiento.Application;

using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Mantenimiento.Application.Equipment.UseCases;
using MediatR;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Registra automáticamente todos los validadores de FluentValidation en este proyecto
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Registra automáticamente todos los manejadores de MediatR en este proyecto
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        return services;
    }
}

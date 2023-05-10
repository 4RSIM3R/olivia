using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Olivia.DTOs;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RegisterTenant>, RegisterTenantValidator>();
        return services;
    }
}

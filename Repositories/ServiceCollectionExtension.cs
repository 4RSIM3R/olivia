using Microsoft.Extensions.DependencyInjection;
using Olivia.RepositoryInterfaces;

namespace Olivia.Repositories;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddOliviaRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICandidateRepository, PlanRepository>();
        services.AddScoped<IAuthTenantRepository, AuthTenantRepository>();
        return services;
    }
}

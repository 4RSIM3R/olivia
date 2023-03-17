using Microsoft.Extensions.DependencyInjection;
using Olivia.RepositoryInterfaces;

namespace Olivia.Repositories;

public static class ServiceCollection
{
    public static IServiceCollection AddOliviaRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IPlanRepository, PlanRepository>();
        return services;
    }
}

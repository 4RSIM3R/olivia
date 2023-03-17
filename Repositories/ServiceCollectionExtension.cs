namespace Olivia.Repositories;

public static class ServiceCollection
{
    public static IServiceCollection AddOliviaRepositories(this IServiceCollection services)
    {
        services.AddSingleton<PlanRepository>();
        return services;
    }
}

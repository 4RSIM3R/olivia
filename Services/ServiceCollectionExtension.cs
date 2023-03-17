namespace Olivia.Services;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddOliviaServices(this IServiceCollection services)
    {
        services.AddTransient<PlanService>();
        return services;
    }
}

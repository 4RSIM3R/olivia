using Microsoft.Extensions.DependencyInjection;
using Olivia.Services.PlanDomain;

namespace Olivia.Services;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddOliviaServices(this IServiceCollection services)
    {
        services.AddTransient<PlanService>();
        return services;
    }
}

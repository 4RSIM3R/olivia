using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Olivia.Entites;

namespace Olivia.Entities;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services)
    {
        services.AddDbContextPool<ApplicationDbContext>((serviceProvider, options) =>
        {
            var dbOptions = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;
            var connectionString = $"Server={dbOptions.Server};Database={dbOptions.Database};Uid={dbOptions.Username};Pwd={dbOptions.Password};";
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
        return services;
    }
}

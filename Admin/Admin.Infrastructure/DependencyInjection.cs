using Admin.Domain.Abstractions;
using Admin.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Admin.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseLazyLoadingProxies();
            
            options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
                .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning))
                .EnableSensitiveDataLogging();
        });

        services.AddScoped<DapperContext>();
        services.AddSingleton<IRedisCacheService, RedisCacheService>();
        services.AddPersistence();

        return services;
    }

    private static void AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork>(ctx =>
        {
            var efCoreDbContext = ctx.GetRequiredService<ApplicationDbContext>();
            var dapperDbContext = ctx.GetRequiredService<DapperContext>();
            var redisCacheService = ctx.GetRequiredService<RedisCacheService>();

            return new UnitOfWork(efCoreDbContext, dapperDbContext, redisCacheService);
        });
        services.AddScoped<IActionTransactionHelper, ActionTransactionHelper>();
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Domain.Abstractions;
using Web.Infrastructure.Repositories;

namespace Web.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WebDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("WebDb"));
        });

        services.AddScoped<WebDapperContext>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddPersistence();

        return services;
    }

    private static void AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork>(ctx =>
        {
            var efCoreDbContext = ctx.GetRequiredService<WebDbContext>();

            return new UnitOfWork(efCoreDbContext);
        });

        services.AddScoped<IActionTransactionHelper, ActionTransactionHelper>();
    }
}

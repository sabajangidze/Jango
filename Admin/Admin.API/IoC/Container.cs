using Admin.API.Filters;
using Admin.Domain.Abstractions;
using Admin.Infrastructure;
using Admin.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;

namespace Admin.IoC;

public static class Container
{
    public static void Setup(IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddMediatr(services);
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseLazyLoadingProxies();
            options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
                   .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning)).EnableSensitiveDataLogging();
        });

        services.AddScoped<IUnitOfWork>(ctx => new UnitOfWork(
            ctx.GetRequiredService<ApplicationDbContext>(),
            ctx.GetRequiredService<DapperContext>()));
        services.AddScoped<IActionTransactionHelper, ActionTransactionHelper>();
        services.AddScoped<UnitOfWorkFilterAttribute>();
        services.AddSingleton<DapperContext>();
    }

    private static void AddMediatr(IServiceCollection services)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}

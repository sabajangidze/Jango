using Admin.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Admin.IoC;

public static class Container
{
    public static void Setup(IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
    }

    public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseLazyLoadingProxies();
            options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
                   .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning)).EnableSensitiveDataLogging();
        });
    }
}

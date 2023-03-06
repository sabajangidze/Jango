using Admin.API.Filters;
using Admin.Application.Utils.Profiles;

namespace Admin.API.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddFilterAttributes();
        
        services.AddMapper();

        return services;
    }

    private static void AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(CustomerProfile));
    }

    private static void AddFilterAttributes(this IServiceCollection services)
    {
        services.AddScoped<UnitOfWorkFilterAttribute>();
    }
}

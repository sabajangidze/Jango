using Admin.API.Filters;
using Admin.Application.CustomersAggregate.Commands;
using Admin.Application.Utils.Profiles;
using Admin.Domain.Abstractions;
using Admin.Infrastructure.Repositories;
using MassTransit;

namespace Admin.API.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton<IRedisCacheService, RedisCacheService>();
        services.AddFilterAttributes();
        services.AddMassTransits();
        services.AddMapper();
        services.AddRedis(configuration);

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

    private async static void AddMassTransits(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddMassTransit(config => {

            config.AddConsumer<Consumer>();

            config.UsingRabbitMq((ctx, cfg) => {
                cfg.Host("amqp://guest:guest@localhost:5672");

                cfg.ReceiveEndpoint("customer-created-event", c => {
                    c.ConfigureConsumer<Consumer>(ctx);
                });
            });
        });
    }

    private static void AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(redisOptions =>
        {
            string connection = configuration.GetConnectionString("Redis");

            redisOptions.Configuration = connection;
        });
    }
}

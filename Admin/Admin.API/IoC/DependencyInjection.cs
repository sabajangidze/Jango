using Admin.API.Filters;
using Admin.Application.CustomersAggregate.Commands;
using Admin.Application.Utils.Profiles;
using MassTransit;

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
        services.AddMassTransits();
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
}

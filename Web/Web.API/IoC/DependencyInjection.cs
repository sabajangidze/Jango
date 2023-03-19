using MassTransit;
using Web.API.Filters;

namespace Web.API.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMassTransit();

            return services;
        }

        private static void AddFilterAttributes(this IServiceCollection services)
        {
            services.AddScoped<UnitOfWorkFilterAttribute>();
        }

        private static void AddMassTransit(this IServiceCollection services)
        {
            services.AddMassTransit(config => {
                config.UsingRabbitMq((ctx, cfg) => {
                    cfg.Host("amqp://guest:guest@localhost:5672");
                });
            });
        }
    }
}

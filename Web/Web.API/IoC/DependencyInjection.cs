using MassTransit;
using Web.API.Filters;
using Web.Domain.Abstractions;
using Web.Infrastructure.Repositories;

namespace Web.API.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit();
            services.AddRedis(configuration);

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

        private static void AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(redisOptions =>
            {
                string connection = configuration.GetConnectionString("Redis");

                redisOptions.Configuration = connection;
            });
        }
    }
}

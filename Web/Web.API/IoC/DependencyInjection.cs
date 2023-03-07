using Plain.RabbitMQ;
using RabbitMQ.Client;
using Web.API.Filters;

namespace Web.API.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            //services.AddRabbitMQ();

            return services;
        }

        private static void AddFilterAttributes(this IServiceCollection services)
        {
            services.AddScoped<UnitOfWorkFilterAttribute>();
        }

        private static void AddRabbitMQ(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionProvider>(new ConnectionProvider("amqp://guest:guest@localhost:5672"));
            services.AddScoped<IPublisher>(x => new Publisher(x.GetService<IConnectionProvider>(),
                "report_exchange",
                ExchangeType.Topic
                ));
        }
    }
}

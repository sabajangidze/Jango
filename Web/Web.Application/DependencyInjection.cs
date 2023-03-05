using Microsoft.Extensions.DependencyInjection;
using Web.Application.CustomerServices;
using Web.Application.Models;
using Web.Domain.Abstractions;
using Web.Domain.Entities;

namespace Web.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddScoped<GetCustomers>();
        services.AddScoped<AddCustomer>(ctx =>
        {
            var repository = ctx.GetRequiredService<IGenericRepository<Customer>>();
            var unitOfWork = ctx.GetRequiredService<IUnitOfWork>();

            return new AddCustomer(repository, unitOfWork);
        });

        return services;
    }
}

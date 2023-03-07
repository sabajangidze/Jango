using Microsoft.Extensions.DependencyInjection;
using Web.Application.Models;
using Web.Application.Services;
using Web.Domain.Abstractions;
using Web.Domain.Entities;

namespace Web.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CustomerServices>();

        return services;
    }
}

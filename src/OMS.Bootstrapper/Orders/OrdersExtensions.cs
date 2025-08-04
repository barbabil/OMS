using Microsoft.Extensions.DependencyInjection;
using OMS.Application.Orders.Repositories.Interfaces;
using OMS.Application.Shared.Settings;
using OMS.Persistence.Orders;

namespace OMS.Bootstrapper.Menu;

public static class OrdersExtensions
{
    public static IServiceCollection AddOrdersRelatedRegistrations(this IServiceCollection services,
                                                                    IAppSettings appSettings)
    {
        services.AddScoped<IOrdersReadRepository, OrdersReadRepository>();

        services.AddScoped<IOrdersWriteRepository, OrdersWriteRepository>();

        return services;
    }
}
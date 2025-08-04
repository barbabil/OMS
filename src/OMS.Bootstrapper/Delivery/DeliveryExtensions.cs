using Microsoft.Extensions.DependencyInjection;
using OMS.Application.Delivery.Repositories.Interfaces;
using OMS.Application.Shared.Settings;
using OMS.Persistence.Orders;

namespace OMS.Bootstrapper.Menu;

public static class DeliveryExtensions
{
    public static IServiceCollection AddDeliveryRelatedRegistrations(this IServiceCollection services,
                                                                    IAppSettings appSettings)
    {
        services.AddScoped<IDeliveryReadRepository, DeliveryReadRepository>();

        services.AddScoped<IDeliveryWriteRepository, DeliveryWriteRepository>();

        return services;
    }
}
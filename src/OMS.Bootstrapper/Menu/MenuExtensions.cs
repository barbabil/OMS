using Microsoft.Extensions.DependencyInjection;
using OMS.Application.Menu.Repositories.Interfaces;
using OMS.Application.Shared.Settings;
using OMS.Persistence.Menu;

namespace OMS.Bootstrapper.Menu;

public static class MenuExtensions
{
    public static IServiceCollection AddMenuRelatedRegistrations(this IServiceCollection services,
                                                                IAppSettings appSettings)
    {
        services.AddScoped<IMenuItemsRepository, MenuItemsRepository>();

        return services;
    }
}
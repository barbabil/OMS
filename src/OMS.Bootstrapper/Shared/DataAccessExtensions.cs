using Microsoft.Extensions.DependencyInjection;
using OMS.Application.Shared.Repositories.Interfaces;
using OMS.Application.Shared.Settings;
using OMS.Persistence.Shared;

namespace OMS.Bootstrapper.Shared;

public static class DataAccessExtensions
{
    public static IServiceCollection AddDataAccessRegistration(this IServiceCollection services,
                                                               IAppSettings appSettings)
    {
        services.AddSingleton<IDbConnectionFactory>(provider =>
                                    new DbConnectionFactory(appSettings));

        return services;
    }
}
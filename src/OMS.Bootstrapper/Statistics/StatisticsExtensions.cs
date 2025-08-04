using Microsoft.Extensions.DependencyInjection;
using OMS.Application.Shared.Settings;
using OMS.Application.Statistics.Repositories.Interfaces;
using OMS.Persistence.Statistics;

namespace OMS.Bootstrapper.Menu;

public static class StatisticsExtensions
{
    public static IServiceCollection AddStatisticsRelatedRegistrations(this IServiceCollection services,
                                                                       IAppSettings appSettings)
    {
        services.AddScoped<IStatisticsRepository, StatisticsRepository>();

        return services;
    }
}
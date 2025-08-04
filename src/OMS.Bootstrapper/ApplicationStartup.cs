using Microsoft.Extensions.DependencyInjection;
using OMS.Application.Shared.Settings;
using OMS.Bootstrapper.Shared;
using OMS.Bootstrapper.Menu;
using OMS.Bootstrapper.Employees;

namespace OMS.Bootstrapper;

public class ApplicationStartup
{
    public static void InitializeWebApiRegistrations(IServiceCollection services,
                                                     IAppSettings appSettings)
    {
        // add DI registrations relevant to MediatR
        services.AddMediatorRegistration();

        // add DI registrations relevant to generic data access
        services.AddDataAccessRegistration(appSettings);

        // add DI registrations relevant to menu
        services.AddMenuRelatedRegistrations(appSettings);

        // add DI registrations relevant to orders
        services.AddOrdersRelatedRegistrations(appSettings);

        // add DI registrations relevant to delivery
        services.AddDeliveryRelatedRegistrations(appSettings);

        // add DI registrations relevant to employees
        services.AddEmployeesRelatedRegistrations(appSettings);

        // add DI registrations relevant to statistics
        services.AddStatisticsRelatedRegistrations(appSettings);
    }
}
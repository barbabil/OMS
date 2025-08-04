using Microsoft.Extensions.DependencyInjection;
using OMS.Application.Employees.Repositories.Interfaces;
using OMS.Application.Shared.Settings;
using OMS.Persistence.Employees;

namespace OMS.Bootstrapper.Employees;

public static class EmployeesExtensions
{
    public static IServiceCollection AddEmployeesRelatedRegistrations(this IServiceCollection services,
                                                                    IAppSettings appSettings)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        return services;
    }
}
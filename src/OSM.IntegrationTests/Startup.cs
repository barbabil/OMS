using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OMS.Application.Shared.Settings;
using OMS.Bootstrapper;

namespace OMS.IntegrationTests;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup()
    {
        _configuration = new ConfigurationBuilder().
                AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).
                Build();
    }

    public void ConfigureHost(IHostBuilder hostBuilder)
    { }

    /// <summary>
    /// Register all services in the native .net DI container
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        var appSettingsSection = _configuration.GetSection("ApplicationSettings");

        // bind our configuration on the appropriate class
        services.Configure<AppSettings>(appSettingsSection);
        var appSettings = appSettingsSection.Get<AppSettings>();

        // register though the native DI container all relevant classes
        ApplicationStartup.InitializeIntegrationTestsRegistrations(services, appSettings);
    }
}
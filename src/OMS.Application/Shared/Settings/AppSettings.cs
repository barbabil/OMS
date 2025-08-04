namespace OMS.Application.Shared.Settings;

public class AppSettings : IAppSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string? Environment { get; set; } = "Development";
}
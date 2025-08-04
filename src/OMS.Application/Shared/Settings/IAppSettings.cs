namespace OMS.Application.Shared.Settings;

public interface IAppSettings
{
    string ConnectionString { get; set; }
    string? Environment { get; set; }
}
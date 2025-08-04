namespace OMS.Application.Menu.Queries.GetMenuItems;

public record GetAvgOrderFullfilmentTimeRequest
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
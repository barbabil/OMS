using OMS.Application.Menu.Queries.GetMenuItems;
using OMS.Application.Statistics.Queries.GetAvgOrderFullfilmentTime;

namespace OMS.Application.Statistics.Repositories.Interfaces;

public interface IStatisticsRepository
{
    public Task<ViewAvgOrderFullfilmentTimeReponse> GetAvgOrderFullfilmentTime(GetAvgOrderFullfilmentTimeQuery query);
}
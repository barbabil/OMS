using OMS.Application.Menu.Queries.GetMenuItems;
using OMS.Application.Statistics.Queries.GetAvgOrderFullfilmentTime;
using OMS.Application.Statistics.Repositories.Interfaces;

namespace OMS.Persistence.Statistics;

public class StatisticsRepository : IStatisticsRepository
{
    public Task<ViewAvgOrderFullfilmentTimeReponse> GetAvgOrderFullfilmentTime(GetAvgOrderFullfilmentTimeQuery query)
    {
        throw new NotImplementedException();
    }
}
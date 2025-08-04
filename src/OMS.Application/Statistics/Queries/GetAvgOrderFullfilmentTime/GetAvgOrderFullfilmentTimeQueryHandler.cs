using OMS.Application.Shared.Queries.Interfaces;
using OMS.Application.Statistics.Queries.GetAvgOrderFullfilmentTime;
using OMS.Application.Statistics.Repositories.Interfaces;

namespace OMS.Application.Menu.Queries.GetMenuItems;

public class GetAvgOrderFullfilmentTimeQueryHandler : IQueryHandler<GetAvgOrderFullfilmentTimeQuery, ViewAvgOrderFullfilmentTimeReponse>
{
    private readonly IStatisticsRepository _statisticsRepository;

    public GetAvgOrderFullfilmentTimeQueryHandler(IStatisticsRepository statisticsRepository)
    {
        _statisticsRepository = statisticsRepository;
    }

    public bool CanExecute(GetAvgOrderFullfilmentTimeQuery query)
    {
        return true;
    }

    public async Task<ViewAvgOrderFullfilmentTimeReponse> Handle(GetAvgOrderFullfilmentTimeQuery query,
                                                                CancellationToken cancellationToken)
    {
        if (!CanExecute(query))
            return new ViewAvgOrderFullfilmentTimeReponse(new List<object>());

        // relevant business logic

        return await _statisticsRepository.GetAvgOrderFullfilmentTime(query);
    }
}
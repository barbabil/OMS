using OMS.Application.Menu.Queries.GetMenuItems;
using OMS.Application.Shared.Queries.Interfaces;

namespace OMS.Application.Statistics.Queries.GetAvgOrderFullfilmentTime;

public record GetAvgOrderFullfilmentTimeQuery : IQuery<ViewAvgOrderFullfilmentTimeReponse>
{
    public GetAvgOrderFullfilmentTimeQuery(GetAvgOrderFullfilmentTimeRequest request)
    {
    }
}
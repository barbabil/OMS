using OMS.Application.Shared.Queries.Interfaces;

namespace OMS.Application.Menu.Queries.GetMenuItems;

public record ViewAvgOrderFullfilmentTimeReponse : IQueryResponse
{
    public Object Result { get; private set; }

    public ViewAvgOrderFullfilmentTimeReponse(object input)
    {
        this.Result = input;
    }
}
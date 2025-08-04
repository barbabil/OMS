using OMS.Application.Shared.Queries.Interfaces;

namespace OMS.Application.Orders.Queries.GetOrders;

public record ViewOrdersResponse : IQueryResponse
{
    public Object Result { get; private set; }

    public ViewOrdersResponse(object input)
    {
        this.Result = input;
    }
}
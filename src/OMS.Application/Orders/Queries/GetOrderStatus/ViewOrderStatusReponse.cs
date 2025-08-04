using OMS.Application.Shared.Queries.Interfaces;

namespace OMS.Application.Orders.Queries.GetOrderStatus;

public record ViewOrderStatusReponse : IQueryResponse
{
    public object Result { get; private set; }

    public ViewOrderStatusReponse(object input)
    {
        Result = input;
    }
}
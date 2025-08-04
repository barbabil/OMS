using OMS.Application.Shared.Queries.Interfaces;

namespace OMS.Application.Orders.Queries.GetOrderStatus;

public record GetOrderStatusQuery : IQuery<ViewOrderStatusReponse>
{
    public GetOrderStatusQuery(Guid orderId)
    {
    }
}
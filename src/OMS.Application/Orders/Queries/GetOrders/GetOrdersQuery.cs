using OMS.Application.Shared.Queries.Interfaces;

namespace OMS.Application.Orders.Queries.GetOrders;

public record GetOrdersQuery : IQuery<ViewOrdersResponse>
{
    public GetOrdersQuery(GetOrdersRequest request)
    {
    }
}
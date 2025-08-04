using OMS.Application.Orders.Queries.GetOrders;
using OMS.Application.Orders.Queries.GetOrderStatus;
using OMS.Domain.Orders;

namespace OMS.Application.Orders.Repositories.Interfaces;

public interface IOrdersReadRepository
{
    public Task<Order?> GetOrderById(Guid orderId);

    public Task<ViewOrdersResponse> GetOrders(GetOrdersQuery query);

    public Task<ViewOrderStatusReponse> GetOrderStatus(GetOrderStatusQuery query);
}
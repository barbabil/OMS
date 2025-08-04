using OMS.Application.Orders.Queries.GetOrders;
using OMS.Application.Orders.Queries.GetOrderStatus;
using OMS.Application.Orders.Repositories.Interfaces;
using OMS.Application.Shared.Repositories.Interfaces;
using OMS.Domain.Menu;
using OMS.Domain.Orders;

namespace OMS.Persistence.Orders;

public class OrdersReadRepository : IOrdersReadRepository
{
    public OrdersReadRepository(IDbConnectionFactory connectionFactory)
    {
    }

    public async Task<Order?> GetOrderById(Guid orderId)
    {
        //return a mock pickup order

        var orderItem = OrderItem.Instantiate(MenuItem.Instantiate("Greek salad", "Greek salad description", 8.5m, true).Value, 2).Value;

        return (PickupOrder.Instantiate(new List<OrderItem> { orderItem }, null).Value);
    }

    public async Task<ViewOrdersResponse> GetOrders(GetOrdersQuery query)
    {
        return new ViewOrdersResponse(new List<object>());
    }

    public async Task<ViewOrderStatusReponse> GetOrderStatus(GetOrderStatusQuery query)
    {
        return new ViewOrderStatusReponse(new List<object>());
    }
}
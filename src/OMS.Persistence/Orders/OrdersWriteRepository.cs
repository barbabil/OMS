using OMS.Application.Orders.Repositories.Interfaces;
using OMS.Application.Shared.Repositories.Interfaces;
using OMS.Domain.Orders;

namespace OMS.Persistence.Orders;

public class OrdersWriteRepository : IOrdersWriteRepository
{
    public OrdersWriteRepository(IDbConnectionFactory connectionFactory)
    {
    }

    public async Task<Guid> NewOrder(Order order)
    {
        return Guid.NewGuid();
    }

    public async Task<bool> SaveOrder(Order order)
    {
        return true;
    }
}
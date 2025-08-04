using OMS.Domain.Orders;

namespace OMS.Application.Orders.Repositories.Interfaces;

/// <summary>
/// Defines a repository for persisting new orders to the data store.
/// </summary>
/// <remarks>This interface is intended for write operations related to orders</remarks>
public interface IOrdersWriteRepository
{
    public Task<Guid> NewOrder(Order order);

    public Task<bool> SaveOrder(Order order);
}
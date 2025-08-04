using OMS.Application.Shared.Repositories.Interfaces;

namespace OMS.Persistence.Orders;

public class DeliveryWriteRepository : IDeliveryWriteRepository
{
    public DeliveryWriteRepository(IDbConnectionFactory connectionFactory)
    {
    }
}
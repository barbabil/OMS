using OMS.Application.Delivery.Queries.GetAssignments;
using OMS.Application.Delivery.Repositories.Interfaces;
using OMS.Application.Shared.Repositories.Interfaces;

namespace OMS.Persistence.Orders;

public class DeliveryReadRepository : IDeliveryReadRepository
{
    public DeliveryReadRepository(IDbConnectionFactory connectionFactory)
    {
    }

    public async Task<ViewAssignmentsReponse> GetAssignments(int employeeId)
    {
        // DB logic to fetch the assignments for a delivery employee (orders marked as "Out for Delivery")
        // We could use a direct fetch here (e.g) without mapping to the domain model,

        return new ViewAssignmentsReponse(new List<object>());
    }
}
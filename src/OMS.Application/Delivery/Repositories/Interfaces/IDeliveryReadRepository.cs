using OMS.Application.Delivery.Queries.GetAssignments;
using OMS.Domain.Orders;

namespace OMS.Application.Delivery.Repositories.Interfaces;

public interface IDeliveryReadRepository
{
    public Task<ViewAssignmentsReponse> GetAssignments(int employeeId);
}
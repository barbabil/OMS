using OMS.Application.Shared.Queries.Interfaces;

namespace OMS.Application.Delivery.Queries.GetAssignments;

public record GetAssignmentsQuery : IQuery<ViewAssignmentsReponse>
{
    public GetAssignmentsQuery(int employeeId)
    {
    }
}
using OMS.Application.Shared.Queries.Interfaces;

namespace OMS.Application.Delivery.Queries.GetAssignments;

public record ViewAssignmentsReponse : IQueryResponse
{
    public Object Result { get; private set; }

    public ViewAssignmentsReponse(object input)
    {
        this.Result = input;
    }
}
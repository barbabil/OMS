using OMS.Application.Delivery.Repositories.Interfaces;
using OMS.Application.Shared.Queries.Interfaces;

namespace OMS.Application.Delivery.Queries.GetAssignments;

public class GetAssignmentsQueryHandler : IQueryHandler<GetAssignmentsQuery, ViewAssignmentsReponse>
{
    private readonly IDeliveryReadRepository _deliveryReadRepository;

    public GetAssignmentsQueryHandler(IDeliveryReadRepository deliveryReadRepository)
    {
        _deliveryReadRepository = deliveryReadRepository;
    }

    public bool CanExecute(GetAssignmentsQuery query)
    {
        return true;
    }

    public async Task<ViewAssignmentsReponse> Handle(GetAssignmentsQuery query,
                                                     CancellationToken cancellationToken)
    {
        //Business logic to fetch the assignments for delivery personnel

        // For now, we are just simulating a call to the repository
        var results = await _deliveryReadRepository.GetAssignments(111);

        return new ViewAssignmentsReponse(new List<object>());
    }
}
using OMS.Application.Orders.Repositories.Interfaces;
using OMS.Application.Shared.Queries.Interfaces;

namespace OMS.Application.Orders.Queries.GetOrders;

public class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery, ViewOrdersResponse>
{
    private readonly IOrdersReadRepository _ordersReadRepository;

    public GetOrdersQueryHandler(IOrdersReadRepository ordersReadRepository)
    {
        _ordersReadRepository = ordersReadRepository;
    }

    public bool CanExecute(GetOrdersQuery query)
    {
        return true;
    }

    public async Task<ViewOrdersResponse> Handle(GetOrdersQuery query,
                                                CancellationToken cancellationToken)
    {
        //Business logic to fetch one or more orders based on criteria and return them

        // For now, we are just simulating a call to the repository
        var results = await _ordersReadRepository.GetOrders(query);

        return new ViewOrdersResponse(new List<object>());
    }
}
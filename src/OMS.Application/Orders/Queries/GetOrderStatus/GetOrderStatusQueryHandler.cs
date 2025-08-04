using OMS.Application.Orders.Repositories.Interfaces;
using OMS.Application.Shared.Queries.Interfaces;

namespace OMS.Application.Orders.Queries.GetOrderStatus;

public class GetOrderStatusQueryHandler : IQueryHandler<GetOrderStatusQuery, ViewOrderStatusReponse>
{
    private readonly IOrdersReadRepository _ordersReadRepository;

    public GetOrderStatusQueryHandler(IOrdersReadRepository ordersReadRepository)
    {
        _ordersReadRepository = ordersReadRepository;
    }

    public bool CanExecute(GetOrderStatusQuery query)
    {
        return true;
    }

    public async Task<ViewOrderStatusReponse> Handle(GetOrderStatusQuery query,
                                                    CancellationToken cancellationToken)
    {
        //Business logic to fetch an order by id and return its status

        // For now, we are just simulating a call to the repository
        var results = await _ordersReadRepository.GetOrderStatus(query);

        return new ViewOrderStatusReponse(new List<object> { });
    }
}
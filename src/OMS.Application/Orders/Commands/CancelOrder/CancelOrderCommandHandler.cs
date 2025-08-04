using CSharpFunctionalExtensions;
using OMS.Application.Orders.Repositories.Interfaces;
using OMS.Application.Shared.Commands.Interfaces;
using OMS.Domain.Shared;

namespace OMS.Application.Orders.Commands.CancelOrder;

public class CancelOrderCommandHandler : ICommandHandler<CancelOrderCommand, Result<bool, Error>>
{
    private readonly IOrdersReadRepository _ordersReadRepository;
    private readonly IOrdersWriteRepository _ordersWriteRepository;

    public CancelOrderCommandHandler(IOrdersReadRepository ordersReadRepository,
                                     IOrdersWriteRepository ordersWriteRepository)
    {
        _ordersWriteRepository = ordersWriteRepository;
        _ordersReadRepository = ordersReadRepository;
    }

    public async Task<Result<bool, Error>> Handle(CancelOrderCommand command,
                                                  CancellationToken cancellationToken)
    {
        var order = await _ordersReadRepository.GetOrderById(command.OrderId);

        order.Cancel();

        var result = await _ordersWriteRepository.SaveOrder(order);

        return result;
    }
}
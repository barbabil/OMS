using CSharpFunctionalExtensions;
using OMS.Application.Orders.Repositories.Interfaces;
using OMS.Application.Shared.Commands.Interfaces;
using OMS.Domain.Shared;

namespace OMS.Application.Orders.Commands.ProgressOrder;

public class ProgressOrderCommandHandler : ICommandHandler<ProgressOrderCommand, Result<bool, Error>>
{
    private readonly IOrdersReadRepository _ordersReadRepository;
    private readonly IOrdersWriteRepository _ordersWriteRepository;

    public ProgressOrderCommandHandler(IOrdersReadRepository ordersReadRepository,
                                    IOrdersWriteRepository ordersWriteRepository)
    {
        _ordersReadRepository = ordersReadRepository;
        _ordersWriteRepository = ordersWriteRepository;
    }

    public async Task<Result<bool, Error>> Handle(ProgressOrderCommand command,
                                            CancellationToken cancellationToken)
    {
        var order = await _ordersReadRepository.GetOrderById(command.OrderId);

        order.ProgressOrder();

        var result = await _ordersWriteRepository.SaveOrder(order);

        return result;
    }
}
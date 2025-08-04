using CSharpFunctionalExtensions;
using OMS.Application.Shared.Commands.Interfaces;
using OMS.Domain.Shared;

namespace OMS.Application.Orders.Commands.ProgressOrder;

public record ProgressOrderCommand : ICommand<Result<bool, Error>>
{
    public ProgressOrderCommand(Guid orderId)
    {
        OrderId = orderId;
    }
    public Guid OrderId { get; }
}
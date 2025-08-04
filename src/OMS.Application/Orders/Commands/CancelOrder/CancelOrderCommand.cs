using CSharpFunctionalExtensions;
using OMS.Application.Shared.Commands.Interfaces;
using OMS.Domain.Shared;

namespace OMS.Application.Orders.Commands.CancelOrder;

public record CancelOrderCommand : ICommand<Result<bool, Error>>
{
    public CancelOrderCommand(Guid orderId)
    {
        OrderId = orderId;
    }
    public Guid OrderId { get; }
}
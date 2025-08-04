using CSharpFunctionalExtensions;
using OMS.Application.Shared;
using OMS.Application.Shared.Commands.Interfaces;
using OMS.Domain.Shared;
using static OMS.Domain.Orders.Order;

namespace OMS.Application.Orders.Commands.PlaceOrder;

public sealed record PlaceOrderCommand : ICommand<Result<Guid, Error>>
{
    public PlaceOrderCommand(PlaceOderRequest request)
    {
    }

    public OrderType OrderType { get; private set; }
    public List<SelectedOrderItem> SelectedOrderItems { get; private set; } = new();
    public CustomerTemplate? Customer { get; private set; }
    public AddressTemplate? Address { get; private set; }
    public string? SpecialInstructions { get; private set; }
}
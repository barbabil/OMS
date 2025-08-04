using CSharpFunctionalExtensions;
using OMS.Application.Menu.Repositories.Interfaces;
using OMS.Application.Orders.Repositories.Interfaces;
using OMS.Application.Shared.Commands.Interfaces;
using OMS.Domain.Orders;
using OMS.Domain.Shared;

namespace OMS.Application.Orders.Commands.PlaceOrder;

public class PlaceOrderCommandHandler : ICommandHandler<PlaceOrderCommand, Result<Guid, Error>>
{
    private readonly IMenuItemsRepository _menuItemsRepository;
    private readonly IOrdersWriteRepository _ordersWriteRepository;

    public PlaceOrderCommandHandler(IOrdersWriteRepository ordersWriteRepository,
                                    IMenuItemsRepository menuItemsRepository)
    {
        _ordersWriteRepository = ordersWriteRepository;
        _menuItemsRepository = menuItemsRepository;
    }

    public async Task<Result<Guid, Error>> Handle(PlaceOrderCommand command,
                                            CancellationToken cancellationToken)
    {
        var customer = command.Customer.ToDomain(command.Address);
        var orderItems = ToOrderItems(command.SelectedOrderItems);
        var notes = Notes.Instantiate(command.SpecialInstructions).Value;

        var order = OrderFactory.GetOrder(command.OrderType, orderItems, customer, notes);

        var result = order.Place();
        if (result.IsFailure)
        {
            return result.Error;
        }

        var orderGuid = await _ordersWriteRepository.NewOrder(order);

        return orderGuid;
    }

    private IReadOnlyList<OrderItem> ToOrderItems(List<SelectedOrderItem> selectedOrderItems)
    {
        var orderItems = new List<OrderItem>();
        foreach (var item in selectedOrderItems)
        {
            var menuItem = _menuItemsRepository.GetMenuItem(item.MenuItemId);
            orderItems.Add(item.ToDomain(menuItem));
        }

        return orderItems;
    }
}
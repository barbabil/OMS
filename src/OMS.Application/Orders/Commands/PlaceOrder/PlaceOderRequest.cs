using OMS.Application.Shared;
using static OMS.Domain.Orders.Order;

namespace OMS.Application.Orders.Commands.PlaceOrder;

public record PlaceOderRequest
{
    public OrderType OrderType { get; set; }
    public List<SelectedOrderItem> SelectedOrderItems { get; set; } = new();
    public CustomerTemplate? Customer { get; set; }
    public AddressTemplate? Address { get; set; }
    public string? SpecialInstructions { get; set; }
}
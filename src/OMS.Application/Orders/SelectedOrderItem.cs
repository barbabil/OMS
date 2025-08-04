using DomainMenuItem = OMS.Domain.Menu.MenuItem;
using DomainOrderItem = OMS.Domain.Orders.OrderItem;

namespace OMS.Application.Orders;

public record SelectedOrderItem
{
    public int MenuItemId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public DomainOrderItem ToDomain(DomainMenuItem menuItem)
    {
        return DomainOrderItem.Instantiate(menuItem, Quantity).Value;
    }
}
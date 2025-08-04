using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;
using OMS.Domain.Menu;
using OMS.Domain.Shared;

namespace OMS.Domain.Orders;

public class OrderItem : Entity<int>
{
    private OrderItem(MenuItem menuItem,
                     int quantity)
    {
        MenuItem = menuItem;
        Quantity = quantity;
    }

    public MenuItem MenuItem { get; private set; }
    public decimal Price => MenuItem.Price * Quantity;
    public int Quantity { get; private set; }

    public static Result<OrderItem, Error> Instantiate(MenuItem menuItem,
                                                       int quantity)
    {
        // menuItem  be null
        Guard.Against.Null(menuItem, nameof(menuItem));
        // quantity must be greater than zero and cannot be negative
        Guard.Against.NegativeOrZero(quantity, nameof(quantity));

        return new OrderItem(menuItem, quantity);
    }

    public void UpdateQuantity(int newQuantity)
    {
    }
}
using CSharpFunctionalExtensions;
using OMS.Domain.Shared;
using OMS.Domain.Shared.Interfaces;

namespace OMS.Domain.Orders;

/// <summary>
/// Represents a customer order, including details such as the customer, order items,  special instructions, and the
/// type of order (e.g., pickup or delivery).
/// </summary>
/// <remarks>The <see cref="Order"/> class serves as the base class for all customer orders.  It provides
/// properties and methods to manage the order's lifecycle, including  placing the order and tracking its status.
/// The <see cref="Order"/>  is also the aggregate root, that is the container to a cluster of domain objects
/// that are treated as a single unit. </remarks>
public abstract class Order : Entity<Guid>, IAggregateRoot
{
    private List<OrderItem> _orderItems = new();

    protected Order(IReadOnlyList<OrderItem> orderItems,
                    Notes? specialInstructions)
    {
        _orderItems = orderItems.ToList();
        SpecialInstructions = specialInstructions;
    }

    public enum OrderType
    {
        Pickup,
        Delivery
    }

    public Customer Customer { get; protected set; } = Customer.PickupCustomer;
    public DateTime? FulfilledAt { get; protected set; }
    public DateTime ModifiedAt { get; protected set; }
    public IReadOnlyList<OrderItem> OrderItems => _orderItems;
    public DateTime PlacedAt { get; protected set; }

    /// <summary>
    /// The customer special instructions associated with the order
    /// </summary>
    public Notes? SpecialInstructions { get; protected set; }

    public OrderType Type { get; protected set; }

    public virtual Result<bool, Error> Cancel()
    {
        ModifiedAt = DateTime.UtcNow;

        return true;
    }

    public virtual Result<bool, Error> Place()
    {
        PlacedAt = DateTime.UtcNow;

        return true;
    }

    public virtual Result<bool, Error> ProgressOrder()
    {
        ModifiedAt = DateTime.UtcNow;

        return true;
    }
}
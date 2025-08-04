using OMS.Domain.Shared;
using static OMS.Domain.Orders.Order;

namespace OMS.Domain.Orders;

public class OrderFactory
{
    /// <summary>
    /// A simple factory method to return an Order instance based on the order type.
    /// </summary>
    /// <param name="orderType"></param>
    /// <param name="orderItems"></param>
    /// <param name="specialInstructions"></param>
    /// <returns></returns>
    public static Order GetOrder(OrderType orderType,
                                IReadOnlyList<OrderItem> orderItems,
                                Customer? customer = null,
                                Notes? specialInstructions = null)
    {
        switch (orderType)
        {
            case OrderType.Delivery:
                return DeliveryOrder.Instantiate(orderItems, customer, specialInstructions).Value;

            case OrderType.Pickup:
                return PickupOrder.Instantiate(orderItems, specialInstructions).Value;

            default:
                throw new ArgumentException($"Invalid order type: {orderType}", nameof(orderType));
        }
    }
}
using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;
using OMS.Domain.Shared;

namespace OMS.Domain.Orders;

public class PickupOrder : Order
{
    private PickupOrder(IReadOnlyList<OrderItem> orderItems,
                        Notes? specialInstructions) : base(orderItems, specialInstructions)
    {
        Type = OrderType.Pickup;

        /// <summary>
        /// In a PickupOrder the customer is not required to give any customer details.
        /// We use a static PickupCustomer to represent this customer.
        ///
        /// Assumption : In reality we may need few customer details like name or phone number
        /// (e.g for a customer waiting for the order)
        /// We will not take this edge case under consideration
        /// </summary>
        Customer = Customer.PickupCustomer;

        // mark the order as pending
        Status = PickupOrderStatus.Pending;
    }

    public PickupOrderStatus Status { get; private set; }

    public static Result<PickupOrder, Error> Instantiate(IReadOnlyList<OrderItem> orderItems,
                                                         Notes? specialInstructions)
    {
        // orderItems cannot be null or empty
        Guard.Against.NullOrEmpty(orderItems, nameof(orderItems));

        return new PickupOrder(orderItems, specialInstructions);
    }

    public override Result<bool, Error> Cancel()
    {
        base.Cancel();

        //transition to the appropriate order status
        var result = Status.Cancel();

        // the order status remained the same. Return an error
        if (result.Value == Status)
            return Result.Failure<bool, Error>
                    (
                        new Error("InvalidStatusTransition", "Cannot cancel an order that is not in Pending state.")
                    );

        Status = result.Value;

        return true;
    }

    public override Result<bool, Error> Place()
    {
        base.Place();

        //transition to the appropriate order status
        var result = Status.ToPreparing();

        // the order status remained the same. Return an error
        if (result.Value == Status)
            return Result.Failure<bool, Error>
                    (
                        new Error("InvalidStatusTransition", "Can only move to Preparing from Pending.")
                    );

        Status = result.Value;

        return true;
    }

    public override Result<bool, Error> ProgressOrder()
    {
        base.ProgressOrder();

        var result = Status.Progress();

        // the order status remained the same. Return an error
        if (result.Value == Status)
            return Result.Failure<bool, Error>
                    (
                        new Error("InvalidStatusTransition", "Invalid order status transition")
                    );

        Status = result.Value;

        return true;
    }
}
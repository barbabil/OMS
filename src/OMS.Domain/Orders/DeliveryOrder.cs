using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;
using OMS.Domain.Employees;
using OMS.Domain.Shared;

namespace OMS.Domain.Orders;

public class DeliveryOrder : Order
{
    private DeliveryOrder(IReadOnlyList<OrderItem> orderItems,
                          Customer customer,
                          Notes? specialInstructions) : base(orderItems, specialInstructions)
    {
        Customer = customer;
        Address = customer.PrimaryAddress;
        Type = OrderType.Delivery;

        // mark the order as pending
        Status = DeliveryOrderStatus.Pending;
    }

    public Address Address { get; private set; }

    public DeliveryOrderStatus Status { get; private set; }

    public static Result<DeliveryOrder, Error> Instantiate(IReadOnlyList<OrderItem> orderItems,
                                                           Customer customer,
                                                           Notes? specialInstructions)
    {
        // orderItems cannot be null or empty
        Guard.Against.NullOrEmpty(orderItems, nameof(orderItems));
        // customer and address cannot be null
        Guard.Against.Null(customer, nameof(customer));

        return new DeliveryOrder(orderItems, customer, specialInstructions);
    }

    public Result<bool, Error> AssignToEmployee(Employee employee)
    {
        var result = employee.AssignOrder(this);
        if (result.IsFailure)
        {
            return Result.Failure<bool, Error>(result.Error);
        }

        return result;
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

        //transition to the next order status
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

    /// <summary>
    /// Advances the current delivery status (order status regarding the delivery) to the next stage in the workflow.
    /// </summary>
    /// <remarks>This method updates the <see cref="Status"/> property to reflect the new delivery status. If the
    /// status transition is invalid (i.e., the status remains unchanged), an error is returned.</remarks>
    public Result<bool, Error> ProgressDelivery(string newStatus)
    {
        // business rules for progressing the delivery status

        return true;
    }

    /// <summary>
    /// Advances the current order status to the next stage in the workflow.
    /// </summary>
    /// <remarks>This method updates the <see cref="Status"/> property to reflect the new order status. If the
    /// status transition is invalid (i.e., the status remains unchanged), an error is returned.</remarks>
    public override Result<bool, Error> ProgressOrder()
    {
        base.ProgressOrder();

        var result = Status.ProgressOrder();

        // the order status remained the same. Return an error
        if (result.Value == Status)
            return Result.Failure<bool, Error>
                    (
                        new Error("InvalidStatusTransition", "Invalid order status transition")
                    );

        Status = result.Value;

        return true;
    }

    public Result<bool, Error> UnableToDeliver()
    {
        var result = Status.MarkAsUnableToDeliver();

        // the order status remained the same. Return an error
        if (result.Value == Status)
            return Result.Failure<bool, Error>
                    (
                        new Error("InvalidStatusTransition", "Invalid delivery status transition")
                    );

        Status = result.Value;

        return true;
    }

    public Result<bool, Error> UnassignFromEmployee(Employee employee)
    {
        var result = employee.UnassignOrder(this);
        if (result.IsFailure)
        {
            return Result.Failure<bool, Error>(result.Error);
        }

        return result;
    }
}
using CSharpFunctionalExtensions;

namespace OMS.Domain.Orders;

public class DeliveryOrderStatus : ValueObject
{
    public static readonly DeliveryOrderStatus Cancelled = new DeliveryOrderStatus("Cancelled");
    public static readonly DeliveryOrderStatus Delivered = new DeliveryOrderStatus("Delivered");
    public static readonly DeliveryOrderStatus OutForDelivery = new DeliveryOrderStatus("OutForDelivery");
    public static readonly DeliveryOrderStatus Pending = new DeliveryOrderStatus("Pending");
    public static readonly DeliveryOrderStatus Preparing = new DeliveryOrderStatus("Preparing");
    public static readonly DeliveryOrderStatus ReadyForDelivery = new DeliveryOrderStatus("ReadyForDelivery");
    public static readonly DeliveryOrderStatus UnableToDeliver = new DeliveryOrderStatus("UnableToDeliver");
    private string _value;

    private DeliveryOrderStatus(string value)
    {
        _value = value;
    }

    public string Value => _value;

    public Result<DeliveryOrderStatus> Cancel()
    {
        if (this == Pending)
            return Cancelled;

        return this;
    }

    public Result<DeliveryOrderStatus> InabilityToDeliver()
    {
        MarkAsUnableToDeliver();

        return this;
    }

    public DeliveryOrderStatus Initialize()
    {
        return Pending;
    }

    public Result<DeliveryOrderStatus> MarkAsDelivered()
    {
        if (this == OutForDelivery)
            return Delivered;

        return this;
    }

    public Result<DeliveryOrderStatus> MarkAsOutForDelivery()
    {
        if (this == ReadyForDelivery)
            return OutForDelivery;

        return this;
    }

    public Result<DeliveryOrderStatus> MarkAsReadyForDelivery()
    {
        if (this == Preparing)
            return ReadyForDelivery;

        return this;
    }

    public Result<DeliveryOrderStatus> MarkAsUnableToDeliver()
    {
        if (this == OutForDelivery)
            return UnableToDeliver;

        return this;
    }

    public Result<DeliveryOrderStatus> ProgressDelivery()
    {
        MarkAsOutForDelivery();

        MarkAsDelivered();

        return this;
    }

    public Result<DeliveryOrderStatus> ProgressOrder()
    {
        ToPreparing();

        MarkAsReadyForDelivery();

        return this;
    }

    public Result<DeliveryOrderStatus> ToPreparing()
    {
        if (this == Pending)
            return Preparing;

        return this;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _value;
    }
}
using CSharpFunctionalExtensions;

namespace OMS.Domain.Orders;

public class PickupOrderStatus : ValueObject
{
    public static readonly PickupOrderStatus Cancelled = new PickupOrderStatus("Cancelled");
    public static readonly PickupOrderStatus Pending = new PickupOrderStatus("Pending");
    public static readonly PickupOrderStatus Preparing = new PickupOrderStatus("Preparing");
    public static readonly PickupOrderStatus ReadyForPickup = new PickupOrderStatus("ReadyForPickup");
    private string _value;

    private PickupOrderStatus(string value)
    {
        _value = value;
    }

    public string Value => _value;

    public Result<PickupOrderStatus> Cancel()
    {
        if (this == Pending)
            return Cancelled;

        return this;
    }

    public PickupOrderStatus Initialize()
    {
        return Pending;
    }

    public Result<PickupOrderStatus> MarkAsReadyForPickup()
    {
        if (this == Preparing)
            return ReadyForPickup;

        return this;
    }

    public Result<PickupOrderStatus> Progress()
    {
        ToPreparing();

        MarkAsReadyForPickup();

        return this;
    }

    public Result<PickupOrderStatus> ToPreparing()
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
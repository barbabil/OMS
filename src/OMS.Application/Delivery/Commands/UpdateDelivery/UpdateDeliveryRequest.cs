namespace OMS.Application.Delivery.Commands.UpdateDelivery;

public record UpdateDeliveryRequest
{
    public Guid OrderId { get; set; }

    public int EmployeeId { get; set; }
    public string NewStatus { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;
}
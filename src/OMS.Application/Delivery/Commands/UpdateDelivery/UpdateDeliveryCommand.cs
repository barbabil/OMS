using CSharpFunctionalExtensions;
using OMS.Application.Shared.Commands.Interfaces;
using OMS.Domain.Shared;

namespace OMS.Application.Delivery.Commands.UpdateDelivery;

public class UpdateDeliveryCommand : ICommand<Result<bool, Error>>
{
    public UpdateDeliveryCommand(UpdateDeliveryRequest request)
    { }
}
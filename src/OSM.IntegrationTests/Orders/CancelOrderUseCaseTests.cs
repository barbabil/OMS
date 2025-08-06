using FluentAssertions;
using OMS.Application.Orders.Commands.CancelOrder;
using OMS.Application.Shared.Commands.Interfaces;

namespace OMS.IntegrationTests.Orders;

public class CancelOrderUseCaseTests
{
    private ICommandExecutor _commandExecutor;

    public CancelOrderUseCaseTests(ICommandExecutor commandExecutor)
    {
        _commandExecutor = commandExecutor;
    }

    public static IEnumerable<object[]> OrderIdsToBeCancelled()
    {
        yield return new object[] {
                                    Guid.Parse("4213D266-5938-441E-A3EE-2EA04BEE4203"),
                                    Guid.Parse("394B54EB-6334-46FE-9CBA-6887F3D3E7FF")
                                  };
    }

    [Theory]
    [MemberData(nameof(OrderIdsToBeCancelled))]
    public async Task CancelOrder_OrderIdsToBeCancelled_CancelsOrders(Guid orderId)
    {
        var command = new CancelOrderCommand(orderId);

        //act
        var actual = await _commandExecutor.Execute(command);

        //Assert
        actual.Should().Be(true);
    }
}
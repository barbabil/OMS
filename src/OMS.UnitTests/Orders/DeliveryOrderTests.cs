using FluentAssertions;
using OMS.Domain;
using OMS.Domain.Menu;
using OMS.Domain.Orders;
using OMS.Domain.Shared;

namespace OMS.UnitTests.Orders;

public class DeliveryOrderTests
{
    private readonly Email _email = Email.Instantiate("george@outlook.com").Value;
    private readonly FirstName _firstName = FirstName.Instantiate("George").Value;
    private readonly LastName _lastName = LastName.Instantiate("Papadopoulos").Value;
    private readonly MenuItem _menuItem = MenuItem.Instantiate("Pizza", "Delicious pizza", 12.99m, true).Value;
    private readonly MobilePhoneNumber _mobilePhoneNumber = MobilePhoneNumber.Instantiate("+306979999999").Value;
    private readonly Notes? _notes = Notes.Instantiate("Please deliver after 5 PM").Value;
    private readonly Address _primaryAddres = Address.Instantiate("Solonos", "66A", "Athens", "Center", "11527").Value;

    [Fact]
    public void Place_ValidInputPassed_ShouldSetCorrectTransition()
    {
        // Arrange
        var items = new List<OrderItem>
        {
            OrderItem.Instantiate(_menuItem, 2).Value
        };

        var customer = Customer.Instantiate(_firstName, _lastName, _primaryAddres, _mobilePhoneNumber, _email).Value;

        var deliveryOrderResult = DeliveryOrder.Instantiate(items, customer, _notes);

        deliveryOrderResult.Should().Be(deliveryOrderResult.IsSuccess);

        var deliveryOrder = deliveryOrderResult.Value;

        // Act
        var placeOrderResult = deliveryOrder.Place();

        // Assert
        placeOrderResult.Should().Be(placeOrderResult.IsSuccess);
        deliveryOrder.Status.Should().Be(DeliveryOrderStatus.Preparing);
    }
}
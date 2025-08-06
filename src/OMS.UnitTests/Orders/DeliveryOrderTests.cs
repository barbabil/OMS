using FluentAssertions;
using OMS.Domain;
using OMS.Domain.Menu;
using OMS.Domain.Orders;
using OMS.Domain.Shared;

namespace OMS.UnitTests.Orders;

public class DeliveryOrderTests
{
    [Fact]
    public void Place_ValidInputPassed_ShouldSetCorrectTransition()
    {
        var menuItem = MenuItem.Instantiate("Pizza", "Delicious pizza", 12.99m, true).Value;

        // Arrange
        var items = new List<OrderItem>
        {
            OrderItem.Instantiate(menuItem, 2).Value
        };

        var email = Email.Instantiate("george@outlook.com").Value;
        var firstName = FirstName.Instantiate("George").Value;
        var lastName = LastName.Instantiate("Papadopoulos").Value;
        var mobilePhoneNumber = MobilePhoneNumber.Instantiate("+306979999999").Value;
        var notes = Notes.Instantiate("Please deliver after 5 PM").Value;
        var primaryAddres = Address.Instantiate("Solonos", "66A", "Athens", "Center", "11527").Value;
        var customer = Customer.Instantiate(firstName, lastName, primaryAddres, mobilePhoneNumber, email).Value;

        var deliveryOrderResult = DeliveryOrder.Instantiate(items, customer, notes);

        deliveryOrderResult.Should().Be(deliveryOrderResult.IsSuccess);

        var deliveryOrder = deliveryOrderResult.Value;

        // Act
        var placeOrderResult = deliveryOrder.Place();

        // Assert
        placeOrderResult.Should().Be(placeOrderResult.IsSuccess);
        deliveryOrder.Status.Should().Be(DeliveryOrderStatus.Preparing);
    }
}
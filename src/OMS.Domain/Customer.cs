using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;
using OMS.Domain.Shared;

namespace OMS.Domain;

public class Customer : Entity<long>
{
    /// <summary>
    /// Define a default customer for pickup orders.
    /// </summary>
    public static readonly Customer PickupCustomer =
        new Customer(FirstName.Instantiate("Pickup").Value,
                     LastName.Instantiate("Customer").Value,
                     Address.Instantiate("Pickup Address", "Pickup City", "Number", "Region", "PostalCode").Value,
                     MobilePhoneNumber.Instantiate("1234567890").Value,
                     Email.Instantiate("pickupCustomer@oms.com").Value);

    private List<Address> _addresses = new();

    private Customer(FirstName firstName,
                    LastName lastName,
                    Address primaryAddress,
                    MobilePhoneNumber mobilePhoneNumber,
                    Email email)
    {
        FirstName = firstName;
        LastName = lastName;
        PrimaryAddress = primaryAddress;
        MobilePhoneNumber = mobilePhoneNumber;
        Email = email;
    }

    public IReadOnlyList<Address> Addresses => _addresses;

    public Email Email { get; private set; }

    public FirstName FirstName { get; private set; }

    public LastName LastName { get; private set; }

    public MobilePhoneNumber MobilePhoneNumber { get; private set; }

    public Address PrimaryAddress { get; private set; }

    public static Result<Customer, Error> Instantiate(FirstName firstName,
                                                      LastName lastName,
                                                      Address primaryAddress,
                                                      MobilePhoneNumber mobilePhoneNumber,
                                                      Email email)
    {
        // firstname cannot be null
        Guard.Against.Null(firstName, nameof(firstName));
        // lastname cannot be null
        Guard.Against.Null(lastName, nameof(lastName));
        // primary address cannot be null
        Guard.Against.Null(primaryAddress, nameof(primaryAddress));
        // mobile phone number cannot be null
        Guard.Against.Null(mobilePhoneNumber, nameof(mobilePhoneNumber));
        // mobile phone number cannot be null
        Guard.Against.Null(email, nameof(email));

        return new Customer(firstName, lastName, primaryAddress, mobilePhoneNumber, email);
    }

    public void AddAddress(Address address)
    {
    }

    public void EditAddress(Address oldAddress,
                            Address newAddress)
    {
    }

    public void RemoveAddress(Address address)
    {
    }
}
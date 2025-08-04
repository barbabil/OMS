using OMS.Domain;
using DomainFirstName = OMS.Domain.Shared.FirstName;
using DomainLastName = OMS.Domain.Shared.LastName;
using DomainPhoneNumber = OMS.Domain.Shared.MobilePhoneNumber;
using DomainEmail = OMS.Domain.Shared.Email;

namespace OMS.Application.Shared;

public record CustomerTemplate
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public Customer ToDomain(AddressTemplate address)
    {
        var firstName = DomainFirstName.Instantiate(FirstName).Value;
        var lastName = DomainLastName.Instantiate(LastName).Value;
        var phoneNumber = DomainPhoneNumber.Instantiate(PhoneNumber).Value;
        var email = DomainEmail.Instantiate(Email).Value;

        return Customer.Instantiate(firstName, lastName, address.ToDomain(), phoneNumber, email).Value;
    }
}
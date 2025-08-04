using CSharpFunctionalExtensions;

namespace OMS.Domain.Shared;

public sealed class MobilePhoneNumber : ValueObject
{
    public static Result<MobilePhoneNumber, Error> Instantiate(string mobilePhoneNumber)
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
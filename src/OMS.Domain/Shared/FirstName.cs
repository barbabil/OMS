using CSharpFunctionalExtensions;

namespace OMS.Domain.Shared;

public sealed class FirstName : ValueObject
{
    public static Result<FirstName, Error> Instantiate(string firstName)
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}

using CSharpFunctionalExtensions;

namespace OMS.Domain.Shared;

public sealed class Email : ValueObject
{
    public static Result<Email, Error> Instantiate(string email)
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
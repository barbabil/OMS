namespace OMS.Application.Shared.Exceptions;

public class OMSApplicationException : Exception
{
    public OMSApplicationException(string message, string? details = null) : base(message)
    {
        this.Details = details;
    }

    public string? Details { get; }
}
namespace PollutionPatrol.BuildingBlocks.Application.Exceptions;

public sealed class InvalidRequestException : Exception
{
    public InvalidRequestException(string invalidParamName, string error) :
        this(errors: new Dictionary<string, string[]> { { invalidParamName, new[] { error } } })
    {
    }

    public InvalidRequestException(IDictionary<string, string[]> errors)
    {
        Errors = errors;
    }

    public IDictionary<string, string[]> Errors { get; }
}
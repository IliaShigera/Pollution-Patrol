namespace PollutionPatrol.API.ExceptionHandling;

internal sealed class ProblemDetailsBuilder
{
    private readonly ProblemDetails _problemDetails = new();

    internal ProblemDetailsBuilder WithType(string? type)
    {
        _problemDetails.Type = type;
        return this;
    }

    internal ProblemDetailsBuilder WithTitle(string? title)
    {
        _problemDetails.Title = title;
        return this;
    }

    internal ProblemDetailsBuilder WithStatus(int? status)
    {
        _problemDetails.Status = status;
        return this;
    }
    
    internal ProblemDetailsBuilder WithDetail(string? details)
    {
        _problemDetails.Detail = details;
        return this;
    }

    internal ProblemDetailsBuilder WithInstance(string? instance)
    {
        _problemDetails.Instance = instance;
        return this;
    }

    internal ProblemDetailsBuilder WithExtension(string key, object? value)
    {
        _problemDetails.Extensions.Add(key, value);
        return this;
    }
    
    internal ProblemDetails Build() => _problemDetails;
}
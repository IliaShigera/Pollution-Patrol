namespace PollutionPatrol.BuildingBlocks.Infrastructure.TemplateEngine.Exceptions;

public sealed class TemplateLoadingException : Exception
{
    internal TemplateLoadingException(string message) : base(message)
    {
    }
}
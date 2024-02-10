namespace PollutionPatrol.BuildingBlocks.Application.Exceptions;

public sealed class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string? missingEntityName, string? searchTerm, string? searchValue)
        : this(missingEntityName, searchTerm)
    {
        SearchValue = searchValue;
    }

    public EntityNotFoundException(string? missingEntityName, string? searchTerm)
    {
        MissingEntityName = missingEntityName;
        SearchTerm = searchTerm;
    }

    public string? MissingEntityName { get; }
    public string? SearchTerm { get; }
    public string? SearchValue { get; }
}
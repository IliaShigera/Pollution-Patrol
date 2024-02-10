namespace PollutionPatrol.BuildingBlocks.Domain;

public abstract class Entity
{
    public Guid Id { get; protected set; }

    private List<IDomainEvent>? _domainEvents;
    public IReadOnlyCollection<IDomainEvent>? DomainEvents => _domainEvents?.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents ??= new List<IDomainEvent>();

        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents() => _domainEvents?.Clear();

    protected static void CheckRule(IDomainRule domainRule)
    {
        if (domainRule.IsBroken())
            throw new DomainRuleBrokenException(domainRule);
    }

    protected static async Task CheckRuleAsync(IAsyncDomainRule domainRule,
        CancellationToken cancellationToken = default)
    {
        if (await domainRule.IsBrokenAsync(cancellationToken))
            throw new DomainRuleBrokenException(domainRule);
    }
}
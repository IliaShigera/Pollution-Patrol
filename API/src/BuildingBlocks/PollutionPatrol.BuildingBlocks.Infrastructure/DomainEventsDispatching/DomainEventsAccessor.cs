namespace PollutionPatrol.BuildingBlocks.Infrastructure.DomainEventsDispatching;

internal sealed class DomainEventsAccessor : IDomainEventsAccessor
{
    public IReadOnlyList<IDomainEvent> GetAllDomainEvents(DbContext dbContext)
    {
        var domainEntities = dbContext.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents is not null && x.Entity.DomainEvents.Count > 0);

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents!)
            .ToList();

        return domainEvents;
    }

    public void ClearAllDomainEvents(DbContext dbContext)
    {
        var domainEntities = dbContext.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents is not null && x.Entity.DomainEvents.Count > 0);

        domainEntities.ToList()
            .ForEach(x => x.Entity.ClearDomainEvents());
    }
}
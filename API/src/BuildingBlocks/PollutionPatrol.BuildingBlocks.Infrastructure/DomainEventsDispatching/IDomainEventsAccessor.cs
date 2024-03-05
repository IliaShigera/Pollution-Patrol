namespace PollutionPatrol.BuildingBlocks.Infrastructure.DomainEventsDispatching;

public interface IDomainEventsAccessor
{
    IReadOnlyList<IDomainEvent> GetAllDomainEvents(DbContext dbContext);

    void ClearAllDomainEvents(DbContext dbContext);
}
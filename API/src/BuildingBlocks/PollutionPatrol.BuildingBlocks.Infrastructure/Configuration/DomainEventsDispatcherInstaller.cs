namespace PollutionPatrol.BuildingBlocks.Infrastructure.Configuration;

internal sealed class DomainEventsDispatcherInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDomainEventsAccessor, DomainEventsAccessor>();
        services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();
    }
}
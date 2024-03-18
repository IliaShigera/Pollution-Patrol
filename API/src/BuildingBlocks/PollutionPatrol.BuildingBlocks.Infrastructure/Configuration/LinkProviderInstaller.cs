namespace PollutionPatrol.BuildingBlocks.Infrastructure.Configuration;

internal sealed class LinkProviderInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ILinkProvider, LinkProvider>();
    }
}
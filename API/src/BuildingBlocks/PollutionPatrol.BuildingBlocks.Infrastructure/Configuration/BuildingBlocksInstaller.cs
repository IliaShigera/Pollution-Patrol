namespace PollutionPatrol.BuildingBlocks.Infrastructure.Configuration;

public sealed class BuildingBlocksInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        foreach (var installer in GetInnerInstallers())
            installer.Install(services, configuration);
    }

    private static IEnumerable<IServiceInstaller> GetInnerInstallers()
    {
        yield return new DomainEventsDispatcherInstaller();
        yield return new EmailSenderInstaller();
        yield return new TemplateEngineInstaller();
    }
}
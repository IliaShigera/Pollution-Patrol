namespace PollutionPatrol.API.Configuration.DI;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblies(
                    Assembly.GetExecutingAssembly(),
                    BuildingBlocksDescriptor.InfrastructureAssembly,
                    Modules.Admin.Infrastructure.Configuration.ModuleDescriptor.ApplicationAssembly,
                    Modules.Reporting.Infrastructure.Configuration.ModuleDescriptor.ApplicationAssembly,
                    Modules.UserAccess.Infrastructure.Configuration.ModuleDescriptor.ApplicationAssembly)
                .AddOpenBehavior(typeof(LoggingPipelineBehaviour<,>))
                .AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>)));

        return services;
    }

    internal static IServiceCollection InstallBuildingBlocks(this IServiceCollection services, IConfiguration configuration)
    {
        var installer = new BuildingBlocksInstaller();

        installer.Install(services, configuration);

        return services;
    }

    internal static IServiceCollection InstallModules(this IServiceCollection services, IConfiguration configuration)
    {
        var moduleAssemblies = new[]
        {
            Modules.Admin.Infrastructure.Configuration.ModuleDescriptor.InfrastructureAssembly,
            Modules.Reporting.Infrastructure.Configuration.ModuleDescriptor.InfrastructureAssembly,
            Modules.UserAccess.Infrastructure.Configuration.ModuleDescriptor.InfrastructureAssembly
        };

        var installers = moduleAssemblies
            .SelectMany(a => a.DefinedTypes)
            .Where(IsAssignableToType<IServiceInstaller>)
            .Select(Activator.CreateInstance)
            .Cast<IServiceInstaller>()
            .ToList();

        installers.ForEach(i => i.Install(services, configuration));

        return services;
    }

    private static bool IsAssignableToType<T>(TypeInfo typeInfo) =>
        typeof(T).IsAssignableFrom(typeInfo) &&
        typeInfo is { IsInterface: false, IsAbstract: false };
}
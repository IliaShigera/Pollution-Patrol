namespace PollutionPatrol.BuildingBlocks.Application.Interfaces;

/// <summary>
/// Defines a contract for components that configure external services, cross-cutting 
/// application components (such as modules or background services), and other dependencies 
/// </summary>
/// <remarks>
/// Installers encapsulate setup logic for complex systems, 3rd party libraries, domain-specific 
/// modules, application-wide background services, or other integrations necessary for a 
/// complete application solution.
/// </remarks>
public interface IServiceInstaller
{
    /// <summary>
    /// Performs the necessary configuration actions using the provided dependency injection 
    /// container and configuration source.
    /// </summary>
    /// <param name="services">The ASP.NET Core service collection.</param>
    /// <param name="configuration">The application's configuration.</param>
    void Install(IServiceCollection services, IConfiguration configuration);
}

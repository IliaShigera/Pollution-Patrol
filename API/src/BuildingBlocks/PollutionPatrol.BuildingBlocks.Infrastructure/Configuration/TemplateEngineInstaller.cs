namespace PollutionPatrol.BuildingBlocks.Infrastructure.Configuration;

internal sealed class TemplateEngineInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITemplateLoadingStrategy, EmbeddedTemplateLoadingStrategy>();
        services.AddScoped<IResourceTemplateManager, EmbeddedResourceTemplateManager>();
        services.AddScoped<ITemplateEngine, EmailTemplateEngine>();
    }
}
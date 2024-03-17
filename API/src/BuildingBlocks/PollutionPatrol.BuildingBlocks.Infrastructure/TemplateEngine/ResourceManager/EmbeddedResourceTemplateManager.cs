namespace PollutionPatrol.BuildingBlocks.Infrastructure.TemplateEngine.ResourceManager;

/// <summary>
/// Manages loading template resources embedded within an assembly.
/// </summary>
internal sealed class EmbeddedResourceTemplateManager : IResourceTemplateManager
{
    private readonly ITemplateLoadingStrategy _strategy;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmbeddedResourceTemplateManager"/> class.
    /// </summary>
    /// <param name="strategy">The strategy to use for loading templates.</param>
    internal EmbeddedResourceTemplateManager(ITemplateLoadingStrategy strategy)
    {
        _strategy = strategy;
    }

    /// <summary>
    /// Loads a template with the specified name.
    /// </summary>
    /// <param name="templateName">The name of the template.</param>
    /// <returns>An object representing the loaded template.</returns>
    public ILoadedTemplate Resolve(string templateName)
    {
        var loadedTemplate = _strategy.LoadTemplate(templateName);
        return loadedTemplate;
    }
}
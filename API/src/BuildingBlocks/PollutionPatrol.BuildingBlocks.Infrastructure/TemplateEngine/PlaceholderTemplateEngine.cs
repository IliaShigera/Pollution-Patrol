namespace PollutionPatrol.BuildingBlocks.Infrastructure.TemplateEngine;

/// <summary>
/// Provides a simple template engine for rendering templates with models.
/// </summary>
internal sealed class PlaceholderTemplateEngine : ITemplateEngine
{
    /// <summary>
    /// The resource template manager used to load templates.
    /// </summary>
    private readonly IResourceTemplateManager _resourceTemplateManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaceholderTemplateEngine"/> class.
    /// </summary>
    /// <param name="resourceTemplateManager">The template manager for resolving templates.</param>
    public PlaceholderTemplateEngine(IResourceTemplateManager resourceTemplateManager)
    {
        _resourceTemplateManager = resourceTemplateManager;
    }

    /// <summary>
    /// Renders a template with a provided view model.
    /// </summary>
    /// <typeparam name="T">The type of the view model.</typeparam>
    /// <param name="templateName">The name of the template to render.</param>
    /// <param name="model">The view model to use during rendering.</param>
    /// <returns>The rendered content.</returns>
    public string RenderTemplate<T>(string templateName, T model) where T : class
    {
        var templateSource = _resourceTemplateManager.Resolve(templateName);
        var template = templateSource.Content;

        var properties = model.GetType().GetProperties();

        foreach (var property in properties)
        {
            var token = $"{{{{{property.Name}}}}}";
            var value = property.GetValue(model)?.ToString();
            template = templateSource.Content.Replace(token, value ?? "");
        }

        return template;
    }
}
namespace PollutionPatrol.BuildingBlocks.Infrastructure.TemplateEngine;

/// <summary>
/// Provides a simple template engine for rendering templates with models.
/// </summary>
internal sealed class EmailTemplateEngine : ITemplateEngine
{
    private const string Layout = "_layout.html";
    private const string MainTag = "<main class=\"content\">";


    /// <summary>
    /// The resource template manager used to load templates.
    /// </summary>
    private readonly IResourceTemplateManager _resourceTemplateManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailTemplateEngine"/> class.
    /// </summary>
    /// <param name="resourceTemplateManager">The template manager for resolving templates.</param>
    public EmailTemplateEngine(IResourceTemplateManager resourceTemplateManager)
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
        var layout = _resourceTemplateManager.Resolve(Layout).Content;
        var template = _resourceTemplateManager.Resolve(templateName).Content;
        var mainContentIndex = layout.IndexOf(MainTag, StringComparison.OrdinalIgnoreCase) + MainTag.Length;
        
        // merge template with layout
        var builder = new StringBuilder(layout);
        builder.Insert(mainContentIndex, template);
        
        // replace place holders 
        var properties = model.GetType().GetProperties();

        foreach (var property in properties)
        {
            var token = $"{{{{{property.Name}}}}}";
            var value = property.GetValue(model)?.ToString();
            builder.Replace(token, value ?? "");
        }

        return builder.ToString();
    }
}
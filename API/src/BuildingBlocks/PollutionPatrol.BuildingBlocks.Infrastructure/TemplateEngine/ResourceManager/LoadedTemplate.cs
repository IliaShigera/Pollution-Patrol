namespace PollutionPatrol.BuildingBlocks.Infrastructure.TemplateEngine.ResourceManager;

/// <summary>
/// Represents the loaded template source with its content.
/// </summary>
internal sealed class LoadedTemplate : ILoadedTemplate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LoadedTemplate"/> class.
    /// </summary>
    /// <param name="content">The content of the template file.</param>
    internal LoadedTemplate(string content)
    {
        Content = content;
    }

    /// <summary>
    /// Gets the content of the template.
    /// </summary>
    public string Content { get; }
}
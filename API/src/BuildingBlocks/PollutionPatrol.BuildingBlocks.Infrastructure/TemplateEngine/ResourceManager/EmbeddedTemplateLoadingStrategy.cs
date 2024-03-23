using PollutionPatrol.BuildingBlocks.Infrastructure.TemplateEngine.EmbeddedResources;

namespace PollutionPatrol.BuildingBlocks.Infrastructure.TemplateEngine.ResourceManager;

internal sealed class EmbeddedTemplateLoadingStrategy : ITemplateLoadingStrategy
{
    private Type RootType { get; } = typeof(IEmbeddedResourcesRoot);

    public ILoadedTemplate LoadTemplate(string templateName)
    {
        using var stream = RootType.Assembly.GetManifestResourceStream($"{RootType.Namespace}.{templateName }");
        if (stream == null)
            throw new TemplateLoadingException(
                string.Format("Couldn't load resource '{0}.{1}' from assembly {2}",
                    RootType.Namespace, templateName,
                    RootType.Assembly.FullName));

        using var reader = new StreamReader(stream);

        return new LoadedTemplate(reader.ReadToEnd());
    }
}
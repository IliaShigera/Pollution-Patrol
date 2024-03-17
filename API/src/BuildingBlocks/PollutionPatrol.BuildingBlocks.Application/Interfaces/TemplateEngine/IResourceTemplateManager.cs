namespace PollutionPatrol.BuildingBlocks.Application.Interfaces.TemplateEngine;

public interface IResourceTemplateManager
{
    ILoadedTemplate Resolve(string templateName);
}
namespace PollutionPatrol.BuildingBlocks.Application.Interfaces.TemplateEngine;

public interface ITemplateLoadingStrategy
{
    ILoadedTemplate LoadTemplate(string templateName);
}
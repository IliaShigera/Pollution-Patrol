namespace PollutionPatrol.BuildingBlocks.Application.Interfaces.TemplateEngine;

public interface ITemplateEngine
{
    string RenderTemplate<T>(string templateName, T model) where T : class;
}
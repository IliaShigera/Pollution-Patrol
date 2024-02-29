namespace PollutionPatrol.API.ExceptionHandling.Extensions;

internal static partial class WebAppExtension
{
    internal static WebApplication UseSelectiveExceptionHandler(this WebApplication app)
    {
        app.UseMiddleware<SelectiveExceptionHandlerMiddleware>();
        return app;
    }
}
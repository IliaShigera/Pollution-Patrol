using ILogger = Serilog.ILogger;

namespace PollutionPatrol.API.ExceptionHandling.Middleware;

internal sealed class SelectiveExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public SelectiveExceptionHandlerMiddleware(RequestDelegate next, ILogger logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Unhandled exception during request {path}: {exceptionType}",
                context.Request.Path,
                ex.GetType().Name);

            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var problemDetails = BuildProblemDetails(context, exception);
        FilterSensitiveDetailsIfNeeded(problemDetails);
        await SetProblemDetailsResponseAsync(context, problemDetails);
    }

    private static ProblemDetails BuildProblemDetails(HttpContext context, Exception exception)
    {
        var builder = exception switch
        {
            EntityNotFoundException => new ProblemDetailsBuilder()
                .WithType("https://tools.ietf.org/html/rfc7231#section-6.5.1")
                .WithTitle("Entity not found in database")
                .WithStatus(StatusCodes.Status404NotFound),

            InvalidRequestException => new ProblemDetailsBuilder()
                .WithType("https://tools.ietf.org/html/rfc7231#section-6.5.1")
                .WithTitle("Invalid request")
                .WithStatus(StatusCodes.Status400BadRequest),

            DomainRuleBrokenException => new ProblemDetailsBuilder()
                .WithType("https://tools.ietf.org/html/rfc7231#section-6.5.1")
                .WithTitle("Bad request")
                .WithStatus(StatusCodes.Status400BadRequest),

            _ => new ProblemDetailsBuilder()
                .WithType("https://www.rfc-editor.org/rfc/rfc7231#section-6.6.1")
                .WithTitle("Internal server error")
                .WithStatus(StatusCodes.Status500InternalServerError)
        };

        // Add common details to enhance troubleshooting: 
        var problemDetails = builder
            .WithDetail(exception.ToUserFriendlyMessage())       // User-friendly error description
            .WithInstance(context.Request.Path)                // The URL where the error occurred
            .WithExtension("Exception", exception.GetType().Name)// Exception type for categorization
            .WithExtension("Source", exception.Source)           // Origin of the exception (class/method)
            .WithExtension("StackTrace", exception.StackTrace)  //  Stack trace for debugging 
            .Build();

        return problemDetails;
    }

    private static void FilterSensitiveDetailsIfNeeded(ProblemDetails problem)
    {
        if (ApplicationEnvironment.IsDevelopment) return;

        // Remove stack trace, origin of the exception
        problem.Extensions.Clear();
    }

    private static async Task SetProblemDetailsResponseAsync(HttpContext context, ProblemDetails problem)
    {
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = problem.Status!.Value;
        await context.Response.WriteAsync(JsonConvert.SerializeObject(problem));
    }
}
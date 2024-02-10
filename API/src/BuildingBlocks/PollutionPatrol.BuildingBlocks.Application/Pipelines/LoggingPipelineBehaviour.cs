namespace PollutionPatrol.BuildingBlocks.Application.Pipelines;

public sealed class LoggingPipelineBehaviour<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger _logger;

    public LoggingPipelineBehaviour(ILogger logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        _logger.Information("Handling {@RequestName}", typeof(TRequest).Name);

        try
        {
            var response = await next();

            _logger.Information("Handled suc{@RequestName}", typeof(TRequest).Name);

#if DEBUG
            _logger.Verbose("Request Details: {Request}", request);
#endif

            return response;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Request {@RequestName} failed with an exception", typeof(TRequest).Name);
            throw;
        }
    }
}
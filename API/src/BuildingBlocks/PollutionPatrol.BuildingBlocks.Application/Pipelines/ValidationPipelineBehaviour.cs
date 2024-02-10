namespace PollutionPatrol.BuildingBlocks.Application.Pipelines;

public sealed class ValidationPipelineBehaviour<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationPipelineBehaviour(IValidator<TRequest> validator)
    {
        _validator = validator;
    }

    public ValidationPipelineBehaviour()
    {
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validator != null)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.ToDictionary();
                throw new InvalidRequestException(errors);
            }
        }

        return await next();
    }
}
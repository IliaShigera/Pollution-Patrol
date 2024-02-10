namespace PollutionPatrol.BuildingBlocks.Domain;

public interface IAsyncDomainRule : IRule
{
    Task<bool> IsBrokenAsync(CancellationToken cancellationToken = default);
}
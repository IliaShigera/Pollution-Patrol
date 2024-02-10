namespace PollutionPatrol.BuildingBlocks.Domain;

public interface IDomainRule : IRule
{
    bool IsBroken();
}
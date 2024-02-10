namespace PollutionPatrol.BuildingBlocks.Domain;

public sealed class DomainRuleBrokenException : Exception
{
    public DomainRuleBrokenException(IRule brokenRule)
    {
        BrokenRule = brokenRule;
        Details = brokenRule.Message;
    }
    
    public IRule BrokenRule { get; }
    
    public string Details { get; }
}
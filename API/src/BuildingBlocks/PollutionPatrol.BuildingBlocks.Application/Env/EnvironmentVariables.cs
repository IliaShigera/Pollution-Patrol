namespace PollutionPatrol.BuildingBlocks.Application.Env;

[SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores")]
public abstract partial class ApplicationEnvironment
{
    public const string ASPNETCORE_ENVIRONMENT = nameof(ASPNETCORE_ENVIRONMENT); 
    public const string CONNECTION_STRINGS = nameof(CONNECTION_STRINGS); 
}
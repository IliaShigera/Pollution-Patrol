namespace PollutionPatrol.BuildingBlocks.Application.Env;

public abstract partial class ApplicationEnvironment
{
    public static bool IsDevelopment => Environment.GetEnvironmentVariable(ASPNETCORE_ENVIRONMENT) is "Development";
    public static bool IsProduction => Environment.GetEnvironmentVariable(ASPNETCORE_ENVIRONMENT) is "Production";
}
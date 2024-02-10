namespace PollutionPatrol.BuildingBlocks.Application.Env;

public abstract partial class ApplicationEnvironment
{
    public static bool IsDevelopment => Environment.GetEnvironmentVariable(ASPNETCORE_ENVIRONMENT) is "Development";
    public static bool IsProduction => Environment.GetEnvironmentVariable(ASPNETCORE_ENVIRONMENT) is "Production";

    public static string? GetConnectionStringByModuleName(string module)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(module);

        var variable = $"{CONNECTION_STRINGS}__{module}";
        var connectionString = Environment.GetEnvironmentVariable(variable);
        return connectionString;
    }
}
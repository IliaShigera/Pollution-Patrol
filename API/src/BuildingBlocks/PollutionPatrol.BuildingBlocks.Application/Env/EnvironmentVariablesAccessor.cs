namespace PollutionPatrol.BuildingBlocks.Application.Env;

// EnvironmentVariablesAccessor.cs
public static partial class ApplicationEnvironment
{
    private static string GetRequiredEnvironmentVariable(string variableName)
    {
        var value = Environment.GetEnvironmentVariable(variableName);

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException(
                $"Environment variable '{variableName}' not found. This is required for the application to function.");
        }

        return value;
    }
}
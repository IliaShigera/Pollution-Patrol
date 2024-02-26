namespace PollutionPatrol.BuildingBlocks.Application.Env;

public abstract partial class ApplicationEnvironment
{
    public static string GetConnectionStringByModuleName(string module)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(module);

        var variable = module switch
        {
            "Admin" => CONNECTION_STRINGS_ADMIN,
            "Reporting" => CONNECTION_STRINGS_REPORTING,
            "UserAccess" => CONNECTION_STRINGS_USER_ACCESS,
            
            _ => string.Empty
        };

        var connectionString = GetRequiredEnvironmentVariable(variable);
        return connectionString;
    }

    public static string GetPasswordSecret()
    {
        var secret = GetRequiredEnvironmentVariable(DEV_ONLY__USER__PASSWORD_SECRET);
        return secret;
    }

    public static Uri GetBaseApplicationUri()
    {
        var uri = GetRequiredEnvironmentVariable(APPLICATION_URI);
        return new Uri(uri);
    }

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
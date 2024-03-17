namespace PollutionPatrol.BuildingBlocks.Application.Env;

[SuppressMessage("Info Code Smell", "S1135:Track uses of \"TODO\" tags")]
public static partial class ApplicationEnvironment
{
    // ===================================
    // NOTICE: Direct Environment Access
    // ===================================
    // I currently access environment variables directly within the Application 
    // layer for simplicity. Reasons include:
    // * Needing data like base URI across modules
    // * Prioritizing rapid development in this pet project
    //
    // TODO: Refactor in the future. Consider:
    // * Dedicated providers (ConnectionStringProvider, BaseUriProvider, etc.)
    // * Facade pattern to encapsulate access


    public static bool IsDevelopment => Environment.GetEnvironmentVariable(ASPNETCORE_ENVIRONMENT) is "Development";
    public static bool IsProduction => Environment.GetEnvironmentVariable(ASPNETCORE_ENVIRONMENT) is "Production";

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

    public static (string Name, string EmailAddress, string Password, string Secret, int Port, string Host) GetAppEmailConfig()
    {
        var name = GetRequiredEnvironmentVariable(DEV_ONLY__EMAIL_NAME);
        var emailAddress = GetRequiredEnvironmentVariable(DEV_ONLY__EMAIL_ADDRESS);
        var password = GetRequiredEnvironmentVariable(DEV_ONLY__EMAIL_PASSWORD);
        var secret = GetRequiredEnvironmentVariable(DEV_ONLY__EMAIL_SECRET);
        var port = int.Parse(GetRequiredEnvironmentVariable(DEV_ONLY__EMAIL_PORT));
        var host = GetRequiredEnvironmentVariable(DEV_ONLY__EMAIL_HOST);

        return (name, emailAddress, password, secret, port, host);
    }
}
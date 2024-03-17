namespace PollutionPatrol.BuildingBlocks.Application.Env;

// EnvironmentVariables.cs
[SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores")]
public static partial class ApplicationEnvironment
{
    private const string ASPNETCORE_ENVIRONMENT = nameof(ASPNETCORE_ENVIRONMENT);
    private const string APPLICATION_URI = nameof(APPLICATION_URI);

    private const string CONNECTION_STRINGS_USER_ACCESS = nameof(CONNECTION_STRINGS_USER_ACCESS);
    private const string CONNECTION_STRINGS_REPORTING = nameof(CONNECTION_STRINGS_REPORTING);
    private const string CONNECTION_STRINGS_ADMIN = nameof(CONNECTION_STRINGS_ADMIN);

    // *** IMPORTANT SECURITY NOTE ***
    // The following is for DEVELOPMENT purposes ONLY. In production,
    // this sensitive credential will be replaced with a secure retrieval
    // mechanism using AWS Secrets Manager or a comparable service.
    // Be mindful of system logging when this variable is in use.
    private const string DEV_ONLY__USER__PASSWORD_SECRET = nameof(DEV_ONLY__USER__PASSWORD_SECRET);

    private const string DEV_ONLY__EMAIL_NAME = nameof(DEV_ONLY__EMAIL_NAME);
    private const string DEV_ONLY__EMAIL_ADDRESS = nameof(DEV_ONLY__EMAIL_ADDRESS);
    private const string DEV_ONLY__EMAIL_PASSWORD = nameof(DEV_ONLY__EMAIL_PASSWORD);
    private const string DEV_ONLY__EMAIL_SECRET = nameof(DEV_ONLY__EMAIL_SECRET);
    private const string DEV_ONLY__EMAIL_PORT = nameof(DEV_ONLY__EMAIL_PORT);
    private const string DEV_ONLY__EMAIL_HOST = nameof(DEV_ONLY__EMAIL_HOST);
}
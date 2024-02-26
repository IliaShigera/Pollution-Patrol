namespace PollutionPatrol.BuildingBlocks.Application.Env;

[SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores")]
public abstract partial class ApplicationEnvironment
{
    internal const string ASPNETCORE_ENVIRONMENT = nameof(ASPNETCORE_ENVIRONMENT);
    internal const string APPLICATION_URI = nameof(APPLICATION_URI);

    internal const string CONNECTION_STRINGS_USER_ACCESS = nameof(CONNECTION_STRINGS_USER_ACCESS);
    internal const string CONNECTION_STRINGS_REPORTING = nameof(CONNECTION_STRINGS_REPORTING);
    internal const string CONNECTION_STRINGS_ADMIN = nameof(CONNECTION_STRINGS_ADMIN);

    // *** IMPORTANT SECURITY NOTE ***
    // The following is for DEVELOPMENT purposes ONLY. In production,
    // this sensitive credential will be replaced with a secure retrieval
    // mechanism using AWS Secrets Manager or a comparable service.
    // Be mindful of system logging when this variable is in use.
    internal const string DEV_ONLY__USER__PASSWORD_SECRET = nameof(DEV_ONLY__USER__PASSWORD_SECRET);
}
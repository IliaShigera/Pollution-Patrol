namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Quartz;

[DisallowConcurrentExecution]
internal sealed partial class ExpireRegistrationsJob : IJob
{
    private readonly IUserAccessModule _userAccessModule;
    private readonly ILogger _logger = Log.ForContext<ExpireRegistrationsJob>();

    public ExpireRegistrationsJob(IUserAccessModule userAccessModule)
    {
        _userAccessModule = userAccessModule;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var expiresOn = DateTime.UtcNow.Date;

        try
        {
            _logger.Information($"{nameof(ExpireRegistrationsJob)} executing. Expires on: {expiresOn}");

            await _userAccessModule.ExecuteCommandAsync(new ExpireRegistrationsCommand(expiresOn));

            _logger.Information($"{nameof(ExpireRegistrationsJob)} executed successfully");
        }
        catch (Exception ex)
        {
            _logger.Error(ex, $"An error occurred while executing {nameof(ExpireRegistrationsJob)}");
        }
    }
}

internal sealed partial class ExpireRegistrationsJob
{
    internal static JobKey JobKey => JobKey.Create(nameof(ExpireRegistrationsJob));
    internal static string CronSchedule => "0 */4 * ? * *"; // every 4th hour
    internal static string Desc => "Executes a command to expire registration records in the database based on a given expiration date.";
}
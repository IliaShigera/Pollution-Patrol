namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Configuration;

internal sealed class ModuleInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var connection = ApplicationEnvironment.GetConnectionStringByModuleName(ModuleDescriptor.ModuleName);

        services.AddDbContext<UserAccessDbContext>(options =>
            options.UseNpgsql(connection));

        services.AddScoped<IUserAccessRepository, UserAccessDbContext>();
        services.AddScoped<IPasswordManager, PasswordManager>();
        services.AddScoped<IEmailValidator, EmailValidator>();
        services.AddScoped<IVerificationCodeGenerator, VerificationCodeGenerator>();
        services.AddTransient<IUserAccessModule, UserAccessModule>();

        #region Quartz config

        services.AddQuartz(config =>
        {
            config
                .AddJob<ExpireRegistrationsJob>(ExpireRegistrationsJob.JobKey)
                .AddTrigger(trigger => trigger
                    .ForJob(ExpireRegistrationsJob.JobKey)
                    .StartAt(DateTimeOffset.UtcNow.AddSeconds(5))
                    .WithCronSchedule(ExpireRegistrationsJob.CronSchedule)
                    .WithDescription(ExpireRegistrationsJob.Desc));
        });

        services.AddQuartzHostedService(options =>
        {
            options.WaitForJobsToComplete = true;
        });

        #endregion
    }
}
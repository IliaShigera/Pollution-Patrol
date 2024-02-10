namespace PollutionPatrol.Modules.Reporting.Infrastructure.Configuration;

internal sealed class ModuleInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var connection = ApplicationEnvironment.GetConnectionStringByModuleName(ModuleDescriptor.ModuleName);

        services.AddDbContext<ReportingDbContext>(options =>
            options.UseNpgsql(connection));

        services.AddScoped<IReportingRepository, ReportingDbContext>();
        services.AddTransient<IReportingModule, ReportingModule>();
    }
}
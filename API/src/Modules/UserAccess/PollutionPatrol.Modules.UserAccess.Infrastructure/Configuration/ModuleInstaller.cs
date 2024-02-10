namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Configuration;

internal sealed class ModuleInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var connection = ApplicationEnvironment.GetConnectionStringByModuleName(ModuleDescriptor.ModuleName);

        services.AddDbContext<UserAccessDbContext>(options =>
            options.UseNpgsql(connection));

        services.AddScoped<IUserAccessRepository, UserAccessDbContext>();
        services.AddTransient<IUserAccessModule, UserAccessModule>();
    }
}
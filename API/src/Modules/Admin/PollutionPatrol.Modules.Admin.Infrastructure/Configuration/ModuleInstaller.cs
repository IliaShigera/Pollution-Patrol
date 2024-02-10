namespace PollutionPatrol.Modules.Admin.Infrastructure.Configuration;

internal sealed class ModuleInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var connection = ApplicationEnvironment.GetConnectionStringByModuleName(ModuleDescriptor.ModuleName);

        services.AddDbContext<AdminDbContext>(options =>
            options.UseNpgsql(connection));

        services.AddScoped<IAdminRepository, AdminDbContext>();
        services.AddTransient<IAdminModule, AdminModule>();
    }
}
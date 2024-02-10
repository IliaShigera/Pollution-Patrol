namespace PollutionPatrol.Modules.Admin.Infrastructure.Configuration;

public static class ModuleDescriptor
{
    public static string ModuleName => "Admin";
    public static Assembly ApplicationAssembly => typeof(IAdminModule).Assembly;
    public static Assembly InfrastructureAssembly => typeof(ModuleDescriptor).Assembly;
}
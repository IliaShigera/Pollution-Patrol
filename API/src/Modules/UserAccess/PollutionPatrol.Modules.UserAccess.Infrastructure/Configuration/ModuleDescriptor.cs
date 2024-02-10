namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Configuration;

public static class ModuleDescriptor
{
    public static string ModuleName => "UserAccess";
    public static Assembly ApplicationAssembly => typeof(IUserAccessModule).Assembly;
    public static Assembly InfrastructureAssembly => typeof(ModuleDescriptor).Assembly;
}
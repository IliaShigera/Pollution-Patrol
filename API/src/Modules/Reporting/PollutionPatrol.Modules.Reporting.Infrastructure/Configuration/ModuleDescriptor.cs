namespace PollutionPatrol.Modules.Reporting.Infrastructure.Configuration;

public static class ModuleDescriptor
{
    public static string ModuleName => "Reporting";

    public static Assembly ApplicationAssembly => typeof(IReportingModule).Assembly;
    public static Assembly InfrastructureAssembly => typeof(ModuleDescriptor).Assembly;
}
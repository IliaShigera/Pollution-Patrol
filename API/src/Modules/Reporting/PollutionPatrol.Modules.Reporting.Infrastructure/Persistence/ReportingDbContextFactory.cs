namespace PollutionPatrol.Modules.Reporting.Infrastructure.Persistence;

internal sealed class ReportingDbContextFactory : IDesignTimeDbContextFactory<ReportingDbContext>
{
    public ReportingDbContext CreateDbContext(string[] args)
    {
        var connection = args[0];

        var optionsBuilder = new DbContextOptionsBuilder<ReportingDbContext>();
        optionsBuilder.UseNpgsql(connection);

        return new ReportingDbContext(optionsBuilder.Options);
    }
}
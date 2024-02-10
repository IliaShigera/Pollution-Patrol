namespace PollutionPatrol.Modules.Admin.Infrastructure.Persistence;

internal sealed class AdminDbContextFactory : IDesignTimeDbContextFactory<AdminDbContext>
{
    public AdminDbContext CreateDbContext(string[] args)
    {
        var connection = args[0];

        var optionsBuilder = new DbContextOptionsBuilder<AdminDbContext>();
        optionsBuilder.UseNpgsql(connection);

        return new AdminDbContext(optionsBuilder.Options);
    }
}
namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Persistence;

internal sealed class UserAccessDbContextFactory : IDesignTimeDbContextFactory<UserAccessDbContext>
{
    public UserAccessDbContext CreateDbContext(string[] args)
    {
        var connection = args[0];

        var optionsBuilder = new DbContextOptionsBuilder<UserAccessDbContext>();
        optionsBuilder.UseNpgsql(connection);

        return new UserAccessDbContext(optionsBuilder.Options);
    }
}
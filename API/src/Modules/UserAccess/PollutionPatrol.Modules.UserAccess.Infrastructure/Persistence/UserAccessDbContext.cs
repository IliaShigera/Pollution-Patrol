namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Persistence;

internal sealed class UserAccessDbContext : DbContext, IUserAccessRepository
{
    public UserAccessDbContext(DbContextOptions<UserAccessDbContext> options) : base(options)
    {
    }

    public DbSet<Registration> Registrations { get; private set; }

    public async Task CommitAsync(CancellationToken cancellationToken = default) =>
        await SaveChangesAsync(cancellationToken);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration.EntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new RegistrationEntityTypeConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}
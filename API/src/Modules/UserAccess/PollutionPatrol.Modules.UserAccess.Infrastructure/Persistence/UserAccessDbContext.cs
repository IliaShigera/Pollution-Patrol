namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Persistence;

internal sealed class UserAccessDbContext : DbContext, IUserAccessRepository
{
    private readonly IDomainEventsDispatcher _domainEventsDispatcher;

    public UserAccessDbContext(DbContextOptions<UserAccessDbContext> options, IDomainEventsDispatcher domainEventsDispatcher)
        : base(options)
    {
        _domainEventsDispatcher = domainEventsDispatcher;
    }

    public DbSet<Registration> Registrations { get; private set; }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await SaveChangesAsync(cancellationToken);

        await _domainEventsDispatcher.DispatchEventsAsync(this, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration.EntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new RegistrationEntityTypeConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}
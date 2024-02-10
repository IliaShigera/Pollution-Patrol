namespace PollutionPatrol.Modules.Admin.Infrastructure.Persistence;

internal sealed class AdminDbContext : DbContext, IAdminRepository
{
    public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
    {
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default) =>
        await SaveChangesAsync(cancellationToken);
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration.EntityTypeConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
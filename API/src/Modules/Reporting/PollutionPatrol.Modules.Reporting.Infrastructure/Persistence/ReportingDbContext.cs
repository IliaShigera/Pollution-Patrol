namespace PollutionPatrol.Modules.Reporting.Infrastructure.Persistence;

internal sealed class ReportingDbContext : DbContext, IReportingRepository
{
    public ReportingDbContext(DbContextOptions<ReportingDbContext> options) : base(options)
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
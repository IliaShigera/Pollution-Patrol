namespace PollutionPatrol.BuildingBlocks.Application.Interfaces;

/// <summary>
/// Provides a foundation for modular unit of work interfaces (IDbContexts). 
/// Each module should define its own IDbContext inheriting from IUnitOfWork, 
/// including appropriateDbSets for the module's entities. This streamlines data access 
/// using Entity Framework Core's built-in CRUD operations.
/// </summary>
/// <example>
/// <code>
/// // Module-specific IDbContext
/// public interface IReportingModuleDbContext : IUnitOfWork
/// {
///     DbSet<Report/> Reports { get; } 
/// }
///
/// // Implementation
/// public class ReportingDbContext : DbContext, IReportingModuleDbContext
/// {
///     public DbSet<Report/> Reports { get; set; } // Note: Can set access modifiers as needed 
/// }
///
/// // Usage in a command handler
/// public class GetReportHandler
/// {
///     private IReportingModuleDbContext _dbContext;
///
///     public GetReportHandler(IReportingModuleDbContext dbContext) 
///     {
///         _dbContext = dbContext;
///     }
///
///     public async Task<Report/> Handler(GetReportCommand command)
///     {
///         return await _dbContext.Reports.FirstOrDefaultAsync(r => r.Id == command.ReportId); 
///     } 
/// }
/// </code>
/// </example>
public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken = default);
}

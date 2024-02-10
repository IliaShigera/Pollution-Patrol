namespace PollutionPatrol.Modules.Reporting.Application.Contracts;

/// <summary>
/// Serves as a generic data access interface for entities within the Reporting module. 
/// Provides direct access to DbSets for flexible querying and CRUD operations using Entity Framework Core.
/// </summary>
/// <remarks>
/// Unlike traditional domain-driven design repositories focused on a single aggregate root and due to the generic nature
/// this repository does not enforce adherence to the IAggregateRoot pattern. 
/// It is the developer's responsibility to ensure operations are performed within valid aggregate boundaries.
/// </remarks> 
/// <example>
/// <code>
/// public async Task<bool/> DeleteReport(int reportId) 
/// {
///     var user = await _reportingRepository.Reports.FindAsync(reportId);
///     if (user != null)
///     {
///         _reportingRepository.Reports.Remove(user);
///         await _reportingRepository.CommitAsync();
///         return true;
///     }
///     return false;
/// }
/// </code>
/// </example>
public interface IReportingRepository : IUnitOfWork
{
}
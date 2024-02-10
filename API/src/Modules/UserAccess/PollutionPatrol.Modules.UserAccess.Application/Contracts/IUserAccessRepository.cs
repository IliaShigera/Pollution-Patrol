namespace PollutionPatrol.Modules.UserAccess.Application.Contracts;

/// <summary>
/// Serves as a generic data access interface for entities within the UserAccess module. 
/// Provides direct access to DbSets for flexible querying and CRUD operations using Entity Framework Core.
/// </summary>
/// <remarks>
/// Unlike traditional domain-driven design repositories focused on a single aggregate root and due to the generic nature
/// this repository does not enforce adherence to the IAggregateRoot pattern. 
/// It is the developer's responsibility to ensure operations are performed within valid aggregate boundaries.
/// </remarks> 
/// <example>
/// <code>
/// public async Task<bool/> ChangeName(int userId, string newName) 
/// {
///     var user = await _userAccessRepository.Users.FindAsync(userId);
///     if (user != null)
///     {
///         user.ChangeName(newName);
/// 
///         _userAccessRepository.Users.Update(user);
///         await _userAccessRepository.CommitAsync();
///         return true;
///     }
///     return false;
/// }
/// </code>
/// </example>
public interface IUserAccessRepository : IUnitOfWork
{
}
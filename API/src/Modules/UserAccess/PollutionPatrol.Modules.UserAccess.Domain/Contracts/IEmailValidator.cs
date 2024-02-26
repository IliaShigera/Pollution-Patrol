namespace PollutionPatrol.Modules.UserAccess.Domain.Contracts;

public interface IEmailValidator
{
    Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default);
    Task<bool> IsEmailVerificationPendingAsync(string email, CancellationToken cancellationToken = default);
}
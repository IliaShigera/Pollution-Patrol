namespace PollutionPatrol.Modules.UserAccess.Infrastructure.IdentityUser;

internal sealed class EmailValidator : IEmailValidator
{
    private readonly IUserAccessRepository _repository;

    public EmailValidator(IUserAccessRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default) =>
        !await _repository.Registrations.AnyAsync(reg =>
                reg.Email.Equals(email) &&
                reg.Status.Value.Equals(RegistrationStatus.Verified.Value),
            cancellationToken);

    public async Task<bool> IsEmailVerificationPendingAsync(string email, CancellationToken cancellationToken = default) =>
        await _repository.Registrations.AnyAsync(reg =>
                reg.Email.Equals(email) &&
                reg.Status.Value.Equals(RegistrationStatus.VerificationPending.Value),
            cancellationToken);
}
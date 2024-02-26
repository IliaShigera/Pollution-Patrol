namespace PollutionPatrol.Modules.UserAccess.Domain.Aggregates.Reg.Rules;

internal sealed class UserEmailMustNotBePendingVerificationRule : IAsyncDomainRule
{
    private readonly string _email;
    private readonly IEmailValidator _validator;

    internal UserEmailMustNotBePendingVerificationRule(string email, IEmailValidator validator)
    {
        _email = email;
        _validator = validator;
    }

    public string Message => "This email address is pending verification. Please check your inbox for a confirmation email.";

    public async Task<bool> IsBrokenAsync(CancellationToken cancellationToken = default) =>
        await _validator.IsEmailVerificationPendingAsync(_email, cancellationToken);
}
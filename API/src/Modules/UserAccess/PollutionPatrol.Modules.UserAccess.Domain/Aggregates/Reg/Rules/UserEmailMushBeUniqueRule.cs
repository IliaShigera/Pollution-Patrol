namespace PollutionPatrol.Modules.UserAccess.Domain.Aggregates.Reg.Rules;

internal sealed class UserEmailMushBeUniqueRule : IAsyncDomainRule
{
    private readonly string _email;
    private readonly IEmailValidator _validator;

    internal UserEmailMushBeUniqueRule(string email, IEmailValidator validator)
    {
        _email = email;
        _validator = validator;
    }

    public string Message => "Sorry, this email has already been registered. Please try again with a different email address.";

    public async Task<bool> IsBrokenAsync(CancellationToken cancellationToken = default) => 
        !await _validator.IsEmailUniqueAsync(_email, cancellationToken);
}
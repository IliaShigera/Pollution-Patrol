namespace PollutionPatrol.Modules.UserAccess.Domain.Aggregates.Reg.Rules;

internal sealed class CannotExpireRegistrationBeforeExpirationDateRule : IDomainRule
{
    private readonly Registration _registration;

    internal CannotExpireRegistrationBeforeExpirationDateRule(Registration registration)
    {
        _registration = registration;
    }

    public string Message =>
        $"This registration cannot be expired before the expiration date of {_registration.ExpiresOn}." +
        " Please contact our support if you need assistance.";

    public bool IsBroken() => DateTime.UtcNow < _registration.ExpiresOn;
}
namespace PollutionPatrol.Modules.UserAccess.Domain.Aggregates.Reg.Rules;

internal sealed class CannotExpireVerifiedRegistrationRule : IDomainRule
{
    private readonly Registration _registration;

    internal CannotExpireVerifiedRegistrationRule(Registration registration)
    {
        _registration = registration;
    }

    public string Message => "This registration has already been verified and cannot be expired.";

    public bool IsBroken() => _registration.Status.Equals(RegistrationStatus.Verified);
}
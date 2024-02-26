namespace PollutionPatrol.Modules.UserAccess.Domain.Aggregates.Reg.Rules;

internal sealed class CannotVerifyExpiredRegistrationRule : IDomainRule
{
    private readonly Registration _registration;

    internal CannotVerifyExpiredRegistrationRule(Registration registration)
    {
        _registration = registration;
    }

    public string Message => "This registration has already been expired and cannot be verified.";

    public bool IsBroken() => _registration.Status.Equals(RegistrationStatus.Expired);
}
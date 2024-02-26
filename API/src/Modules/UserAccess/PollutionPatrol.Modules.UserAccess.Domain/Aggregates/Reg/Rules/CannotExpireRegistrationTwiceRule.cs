namespace PollutionPatrol.Modules.UserAccess.Domain.Aggregates.Reg.Rules;

internal sealed class CannotExpireRegistrationTwiceRule : IDomainRule
{
    private readonly Registration _registration;

    internal CannotExpireRegistrationTwiceRule(Registration registration)
    {
        _registration = registration;
    }

    public string Message => "Registration is already expired.";

    public bool IsBroken() => _registration.Status.Equals(RegistrationStatus.Expired);
}
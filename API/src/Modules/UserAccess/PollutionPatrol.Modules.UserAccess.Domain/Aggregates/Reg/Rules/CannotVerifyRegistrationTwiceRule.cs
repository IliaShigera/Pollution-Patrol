namespace PollutionPatrol.Modules.UserAccess.Domain.Aggregates.Reg.Rules;

internal sealed class CannotVerifyRegistrationTwiceRule : IDomainRule
{
    private readonly Registration _registration;

    internal CannotVerifyRegistrationTwiceRule(Registration registration)
    {
        _registration = registration;
    }

    public string Message => "Registration is already verified.";

    public bool IsBroken() => _registration.Status.Equals(RegistrationStatus.Verified);
}
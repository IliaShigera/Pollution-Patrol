namespace PollutionPatrol.Modules.UserAccess.Domain.Aggregates.Reg;

public sealed class RegistrationStatus : ValueObject
{
    private RegistrationStatus(string value)
    {
        Value = value;
    }

    public string Value { get; init; }

    public static RegistrationStatus VerificationPending => new(nameof(VerificationPending));
    public static RegistrationStatus Verified => new(nameof(Verified));
    public static RegistrationStatus Expired => new(nameof(Expired));

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
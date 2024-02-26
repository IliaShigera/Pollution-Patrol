namespace PollutionPatrol.Modules.UserAccess.Domain.Aggregates.Reg;

public sealed class Registration : Entity, IAggregateRoot
{
    private Registration()
    {
        // for EF only
    }

    private Registration(string username, string email, string passwordHash, string verificationCode, DateTime expiresOn)
    {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        VerificationCode = verificationCode;
        ExpiresOn = expiresOn;
        RegisteredOn = DateTime.UtcNow;
        Status = RegistrationStatus.VerificationPending;

        AddDomainEvent(new NewUserRegisteredDomainEvent(username, email, verificationCode));
    }

    public string Username { get; init; }
    public string Email { get; init; }
    public string PasswordHash { get; init; }
    public string VerificationCode { get; init; }
    public DateTime RegisteredOn { get; init; }
    public DateTime ExpiresOn { get; init; }
    public DateTime? VerifiedOn { get; private set; }
    public RegistrationStatus Status { get; private set; }

    public static async Task<Registration> CreateAsync(
        string username,
        string email,
        string passwordHash,
        string verificationToken,
        DateTime expiresOn,
        IEmailValidator emailValidator,
        CancellationToken cancellationToken)
    {
        await CheckRuleAsync(new UserEmailMushBeUniqueRule(email, emailValidator), cancellationToken);
        await CheckRuleAsync(new UserEmailMustNotBePendingVerificationRule(email, emailValidator), cancellationToken);

        return new Registration(username, email, passwordHash, verificationToken, expiresOn);
    }

    public void Verify()
    {
        CheckRule(new CannotVerifyRegistrationTwiceRule(this));
        CheckRule(new CannotVerifyExpiredRegistrationRule(this));

        Status = RegistrationStatus.Verified;
        VerifiedOn = DateTime.UtcNow;

        AddDomainEvent(new RegistrationVerifiedDomainEvent());
    }

    public void Expire()
    {
        CheckRule(new CannotExpireRegistrationTwiceRule(this));
        CheckRule(new CannotExpireVerifiedRegistrationRule(this));
        CheckRule(new CannotExpireRegistrationBeforeExpirationDateRule(this));

        Status = RegistrationStatus.Expired;
        
        AddDomainEvent(new RegistrationExpiredDomainEvent(Username, Email));
    }
}
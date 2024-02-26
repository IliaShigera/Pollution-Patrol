namespace PollutionPatrol.Modules.UserAccess.Domain.Aggregates.Reg.Events;

public sealed class NewUserRegisteredDomainEvent : IDomainEvent
{
    internal NewUserRegisteredDomainEvent(string username, string email, string verificationCode)
    {
        Username = username;
        Email = email;
        VerificationCode = verificationCode;
    }
    
    public string Username { get; }
    public string Email { get; }
    public string VerificationCode { get; }
}
namespace PollutionPatrol.Modules.UserAccess.Domain.Aggregates.Reg.Events;

public sealed class RegistrationExpiredDomainEvent : IDomainEvent
{
    internal RegistrationExpiredDomainEvent(string username, string email)
    {
        Username = username;
        Email = email;
    }

    public string Username { get; }
    public string Email { get; }
}
namespace PollutionPatrol.Modules.UserAccess.Application.Features.Reg.Notification;

internal sealed class SendExpirationEmailHandler : IDomainEventHandler<RegistrationExpiredDomainEvent>
{
    public Task Handle(RegistrationExpiredDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
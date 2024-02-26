namespace PollutionPatrol.Modules.UserAccess.Application.Features.Reg.Notification;

internal sealed class SendVerificationEmailHandler : IDomainEventHandler<NewUserRegisteredDomainEvent>
{
    public Task Handle(NewUserRegisteredDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}

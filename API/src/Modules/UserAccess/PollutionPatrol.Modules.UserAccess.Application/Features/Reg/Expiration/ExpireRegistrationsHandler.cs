namespace PollutionPatrol.Modules.UserAccess.Application.Features.Reg.Expiration;

internal sealed class ExpireRegistrationsHandler : ICommandHandler<ExpireRegistrationsCommand>
{
    private readonly IUserAccessRepository _repository;

    public ExpireRegistrationsHandler(IUserAccessRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(ExpireRegistrationsCommand command, CancellationToken cancellationToken)
    {
        var registration = await _repository.Registrations
            .Where(reg =>
                reg.Status.Value.Equals(RegistrationStatus.VerificationPending.Value) &&
                reg.ExpiresOn <= command.ExpiresOn)
            .ToListAsync(cancellationToken);

        registration.ForEach(reg => reg.Expire());

        _repository.Registrations.UpdateRange(registration);
        await _repository.CommitAsync(cancellationToken);
    }
}
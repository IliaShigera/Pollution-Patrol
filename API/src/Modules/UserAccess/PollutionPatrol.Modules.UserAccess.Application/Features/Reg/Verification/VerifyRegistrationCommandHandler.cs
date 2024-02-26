namespace PollutionPatrol.Modules.UserAccess.Application.Features.Reg.Verification;

internal sealed class VerifyRegistrationCommandHandler : ICommandHandler<VerifyRegistrationCommand>
{
    private readonly IUserAccessRepository _repository;

    public VerifyRegistrationCommandHandler(IUserAccessRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(VerifyRegistrationCommand command, CancellationToken cancellationToken)
    {
        var registration = await _repository.Registrations
            .FirstOrDefaultAsync(reg => reg.VerificationCode.Equals(command.VerificationCode), cancellationToken);

        if (registration is null)
        {
            throw new EntityNotFoundException(
                missingEntityName: nameof(registration),
                searchTerm: nameof(command.VerificationCode),
                searchValue: command.VerificationCode);
        }

        registration.Verify();

        _repository.Registrations.Update(registration);
        await _repository.CommitAsync(cancellationToken);
    }
}
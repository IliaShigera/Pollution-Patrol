namespace PollutionPatrol.Modules.UserAccess.Application.Features.Reg.Registration;

internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
{
    private readonly IUserAccessRepository _repository;
    private readonly IEmailValidator _emailValidator;
    private readonly IPasswordManager _passwordManager;
    private readonly IVerificationCodeGenerator _verificationCodeGenerator;

    public RegisterUserCommandHandler(
        IUserAccessRepository repository,
        IEmailValidator emailValidator,
        IPasswordManager passwordManager,
        IVerificationCodeGenerator verificationCodeGenerator)
    {
        _repository = repository;
        _emailValidator = emailValidator;
        _passwordManager = passwordManager;
        _verificationCodeGenerator = verificationCodeGenerator;
    }
    
    public async Task Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var passwordHash = _passwordManager.HashPassword(command.Password);
        var expiresOn = DateTime.UtcNow.AddHours(RegistrationSettings.ExpirationTimeInHours);
        var verificationCode = _verificationCodeGenerator.GenerateCode(RegistrationSettings.VerificationCodeLength);
        
        var registration = await Domain.Aggregates.Reg.Registration.CreateAsync(
            command.Username,
            command.Email,
            passwordHash,
            verificationCode,
            expiresOn,
            _emailValidator,
            cancellationToken);

        await _repository.Registrations.AddAsync(registration, cancellationToken);
        await _repository.CommitAsync(cancellationToken);
    }
}
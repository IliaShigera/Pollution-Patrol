namespace PollutionPatrol.Modules.UserAccess.Application.Features.Reg.Verification;

public sealed record VerifyRegistrationCommand(string VerificationCode) : ICommand;

internal sealed class VerifyRegistrationCommandValidator : AbstractValidator<VerifyRegistrationCommand>
{
    public VerifyRegistrationCommandValidator()
    {
        RuleFor(command => command.VerificationCode)
            .NotEmpty().WithMessage("Verification code is required.");
    }
}
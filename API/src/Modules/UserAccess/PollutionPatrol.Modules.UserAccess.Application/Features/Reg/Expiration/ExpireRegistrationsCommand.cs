namespace PollutionPatrol.Modules.UserAccess.Application.Features.Reg.Expiration;

public sealed record ExpireRegistrationsCommand(DateTime ExpiresOn) : ICommand;

internal sealed class ExpireRegistrationCommandValidator : AbstractValidator<ExpireRegistrationsCommand>
{
    public ExpireRegistrationCommandValidator()
    {
        RuleFor(x => x.ExpiresOn)
            .NotEmpty().WithMessage("Expiration date is required.");
    }
}
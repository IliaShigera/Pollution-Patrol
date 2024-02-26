namespace PollutionPatrol.Modules.UserAccess.Application.Features.Reg.Registration;

public sealed record RegisterUserCommand(string Username, string Email, string Password) : ICommand;

internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(command => command.Username)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(command => command.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Email address is required.")
            .EmailAddress().WithMessage("Email address must be a valid email.");

        RuleFor(command => command.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(RegistrationSettings.PasswordLengthRequired)
            .WithMessage($"Password must be at least {RegistrationSettings.PasswordLengthRequired} characters long");
    }
}
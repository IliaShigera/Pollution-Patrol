namespace PollutionPatrol.Modules.UserAccess.Application.Features.Reg.Notification;

internal sealed class SendVerificationEmailHandler : IDomainEventHandler<NewUserRegisteredDomainEvent>
{
    private readonly ITemplateEngine _templateEngine;
    private readonly ILinkProvider _linkProvider;
    private readonly IEmailSender _emailSender;

    public SendVerificationEmailHandler(
        ITemplateEngine templateEngine,
        ILinkProvider linkProvider,
        IEmailSender emailSender)
    {
        _templateEngine = templateEngine;
        _linkProvider = linkProvider;
        _emailSender = emailSender;
    }

    public async Task Handle(NewUserRegisteredDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        var body = GetBody(domainEvent.Username, domainEvent.VerificationCode);

        var email = new EmailMessage(
            to: domainEvent.Email,
            subject: "Verify Your Pollution Patrol Account",
            body);

        await _emailSender.SendEmailAsync(email, cancellationToken);
    }

    private string GetBody(string username, string verificationCode)
    {
        var verificationLink = _linkProvider.GetRegistrationVerifyLink(verificationCode);

        var templateModel = new VerificationEmailModel
        {
            Username = username,
            Link = verificationLink,
        };

        var template = _templateEngine.RenderTemplate(TemplateNames.VerifyRegistrationEmailTemplate, templateModel);
        return template;
    }
}
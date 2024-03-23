namespace PollutionPatrol.Modules.UserAccess.Application.Features.Reg.Notification;

internal sealed class SendExpirationEmailHandler : IDomainEventHandler<RegistrationExpiredDomainEvent>
{
    private readonly ITemplateEngine _templateEngine;
    private readonly IEmailSender _emailSender;

    public SendExpirationEmailHandler(ITemplateEngine templateEngine, IEmailSender emailSender)
    {
        _templateEngine = templateEngine;
        _emailSender = emailSender;
    }

    public async Task Handle(RegistrationExpiredDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        var body = GetBody(domainEvent.Username);

        var email = new EmailMessage(
            to: domainEvent.Email,
            subject: "Verification Link Expired",
            body);

        await _emailSender.SendEmailAsync(email, cancellationToken);
    }

    private string GetBody(string username)
    {
        var templateModel = new ExpirationEmailModel
        {
            Username = username,
        };

        var template = _templateEngine.RenderTemplate(TemplateNames.RegistrationExpiredEmailTemplate, templateModel);
        return template;
    }
}
namespace PollutionPatrol.BuildingBlocks.Infrastructure.EmailSending;

internal sealed class SmtpEmailSender : IEmailSender
{
    private readonly EmailConfiguration _configuration;
    private readonly ILogger _logger;

    public SmtpEmailSender(IOptions<EmailConfiguration> options, ILogger logger)
    {
        _configuration = options.Value;
        _logger = logger;
    }

    public async Task SendEmailAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default)
    {
        using var mineMessage = BuildMineMessage(emailMessage);

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_configuration.Host, _configuration.Port, useSsl: false, cancellationToken);
        await smtp.AuthenticateAsync(userName: _configuration.FromEmail, _configuration.Password, cancellationToken);
        await smtp.SendAsync(mineMessage, cancellationToken);
        await smtp.DisconnectAsync(quit: true, cancellationToken);

#if DEBUG
        _logger.Information("Email sent. From: {From}, To: {To}, Subject: {Subject}, Content: {Content}.",
            _configuration.FromEmail,
            emailMessage.To,
            emailMessage.Subject,
            emailMessage.Body);
#else
        _logger.Information("Email sent. From: {From}, To: {To}, Subject: {Subject}, Content: {Content}.",
            _configuration.FromEmail,
            message.To,
            message.Subject)
#endif
    }

    private MimeMessage BuildMineMessage(EmailMessage emailMessage)
    {
        var mineMessage = new MimeMessage();
        mineMessage.From.Add(new MailboxAddress(_configuration.FromName, _configuration.FromEmail));
        mineMessage.To.Add(new MailboxAddress(default, emailMessage.To));
        mineMessage.Subject = emailMessage.Subject;

        var multipart = new Multipart("alternative");

        multipart.Add(new TextPart(TextFormat.Plain)
        {
            Text = emailMessage.Body
        });

        multipart.Add(new TextPart(TextFormat.Html)
        {
            Text = emailMessage.Body
        });

        mineMessage.Body = multipart;

        return mineMessage;
    }
}
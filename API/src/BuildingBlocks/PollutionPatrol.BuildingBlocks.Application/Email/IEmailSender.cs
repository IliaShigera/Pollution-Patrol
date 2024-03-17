namespace PollutionPatrol.BuildingBlocks.Application.Email;

public interface IEmailSender
{
    Task SendEmailAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default);
}
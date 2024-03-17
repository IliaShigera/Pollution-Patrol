namespace PollutionPatrol.BuildingBlocks.Infrastructure.EmailSending;

internal sealed class EmailConfiguration
{
    internal string FromName { get; set; }
    internal string FromEmail { get; set; }
    internal string Password { get; set; }
    internal string Secret { get; set; }
    internal int Port { get; set; }
    internal string Host { get; set; }
}
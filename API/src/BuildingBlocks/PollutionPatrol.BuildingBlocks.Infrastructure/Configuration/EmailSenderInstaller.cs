namespace PollutionPatrol.BuildingBlocks.Infrastructure.Configuration;

internal sealed class EmailSenderInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var (name, emailAddress, password, secret, port, host) = ApplicationEnvironment.GetAppEmailConfig();

        services.Configure<EmailConfiguration>(options =>
        {
            options.FromName = name;
            options.FromEmail = emailAddress;
            options.Password = password;
            options.Secret = secret;
            options.Port = port;
            options.Host = host;
        });

        services.AddScoped<IEmailSender, SmtpEmailSender>();
    }
}
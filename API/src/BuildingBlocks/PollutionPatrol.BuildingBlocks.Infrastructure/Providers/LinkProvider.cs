namespace PollutionPatrol.BuildingBlocks.Infrastructure.Providers;

internal sealed class LinkProvider : ILinkProvider
{
    private const string RegistrationVerifyEndpoint = "api/registration/verify";
    
    public string GetRegistrationVerifyLink(string verificationCode)
    {
        var baseUri = ApplicationEnvironment.GetBaseApplicationUri();
        var link = $"{baseUri}/{RegistrationVerifyEndpoint}/{verificationCode}";
        
        return link;
    }
}
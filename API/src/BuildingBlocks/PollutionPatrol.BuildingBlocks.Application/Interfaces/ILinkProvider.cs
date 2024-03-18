namespace PollutionPatrol.BuildingBlocks.Application.Interfaces;

public interface ILinkProvider
{
    string GetRegistrationVerifyLink(string verificationCode);
}
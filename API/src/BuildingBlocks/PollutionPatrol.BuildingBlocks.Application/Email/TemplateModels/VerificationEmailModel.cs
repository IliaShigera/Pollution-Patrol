namespace PollutionPatrol.BuildingBlocks.Application.Email.TemplateModels;

public sealed class VerificationEmailModel
{
    public string Username { get; set; }
    public string Link { get; set;  }
}
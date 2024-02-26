namespace PollutionPatrol.Modules.UserAccess.Application.Contracts;

public interface IVerificationCodeGenerator
{
    string GenerateCode(int length);
}
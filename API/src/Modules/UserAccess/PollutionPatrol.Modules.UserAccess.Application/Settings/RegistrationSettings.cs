namespace PollutionPatrol.Modules.UserAccess.Application.Settings;

internal abstract class RegistrationSettings
{
    internal const int ExpirationTimeInHours = 2;
    internal const int PasswordLengthRequired = 7;
    internal const int VerificationCodeLength = 8;
}
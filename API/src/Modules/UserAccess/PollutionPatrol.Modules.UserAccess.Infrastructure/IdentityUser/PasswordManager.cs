namespace PollutionPatrol.Modules.UserAccess.Infrastructure.IdentityUser;

internal sealed class PasswordManager : IPasswordManager
{
    public string HashPassword(string password)
    {
        var secret = ApplicationEnvironment.GetPasswordSecret();
        var hash = Argon2.Hash(password, secret);
        return hash;
    }

    public bool VerifyPassword(string password,  string passwordHash)
    {
        var secret = ApplicationEnvironment.GetPasswordSecret();
        return Argon2.Verify(password, passwordHash, secret: secret);
    }
}
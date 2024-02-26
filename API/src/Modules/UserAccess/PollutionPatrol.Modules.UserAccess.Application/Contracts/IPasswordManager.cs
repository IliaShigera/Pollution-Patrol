namespace PollutionPatrol.Modules.UserAccess.Application.Contracts;

public interface IPasswordManager
{
    string HashPassword(string password);

    bool VerifyPassword(string password, string passwordHash);
}
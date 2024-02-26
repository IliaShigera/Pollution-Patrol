namespace PollutionPatrol.Modules.UserAccess.Infrastructure.CodeGenerator;

internal sealed class VerificationCodeGenerator : IVerificationCodeGenerator
{
    public string GenerateCode(int length)
    {
        var nonce = Guid.NewGuid();

        var epochStart = DateTime.UnixEpoch;
        var timeSpan = DateTime.UtcNow - epochStart;
        var timeStep = TimeSpan.FromSeconds(30);

        var timestamp = (long)(timeSpan / timeStep);

        var hashInput = $"{timestamp}";
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(nonce.ToString()));
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(hashInput));

        var code = Convert.ToBase64String(hash)
            .Replace("=", "", StringComparison.Ordinal);

        return code[..length];
    }
}
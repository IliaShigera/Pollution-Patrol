namespace PollutionPatrol.API.Controllers.UserAccess;

[ApiController]
[AllowAnonymous]
public sealed class RegistrationController : ApiController
{
    private readonly IUserAccessModule _userAccessModule;

    public RegistrationController(IUserAccessModule userAccessModule)
    {
        _userAccessModule = userAccessModule;
    }

    [HttpPost("registration")]
    public async Task<ActionResult> RegisterUserAsync(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        await _userAccessModule.ExecuteCommandAsync(
            new RegisterUserCommand(
                request.Username,
                request.Email,
                request.Password),
            cancellationToken);

        return Ok();
    }

    [HttpPatch("registration/verify/{verificationCode:required}")]
    public async Task<ActionResult> VerifyRegistrationAsync(string verificationCode, CancellationToken cancellationToken)
    {
        await _userAccessModule.ExecuteCommandAsync(
            new VerifyRegistrationCommand(verificationCode), cancellationToken);

        return Ok();
    }
}
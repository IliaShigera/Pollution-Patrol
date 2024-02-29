using PollutionPatrol.API.ExceptionHandling.Mapper;

namespace PollutionPatrol.API.ExceptionHandling.Extensions;

internal static class ExceptionExtension
{
    internal static string ToUserFriendlyMessage(this Exception exception)
    {
        var message = ExceptionMapper.MapExceptionToUserFriendlyMessage(exception);
        return message;
    }
}
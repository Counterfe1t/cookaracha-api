using System.Net;

namespace Cookaracha.Core.Exceptions;

public sealed class UserNotFoundException : CustomException
{
    public Guid UserId { get; }

    public UserNotFoundException(Guid userId)
        : base($"User with ID: '{userId}' was not found.")
    {
        StatusCode = (int)HttpStatusCode.NotFound;
        UserId = userId;
    }
}
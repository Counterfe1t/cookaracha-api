using System.Net;

namespace Cookaracha.Core.Exceptions;

public sealed class InvalidUserNameException : CustomException
{
    public string UserName { get; }

    public InvalidUserNameException(string userName) : base($"User name: '{userName}' is invalid.")
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
        UserName = userName;
    }
}
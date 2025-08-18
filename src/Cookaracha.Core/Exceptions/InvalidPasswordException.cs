using System.Net;

namespace Cookaracha.Core.Exceptions;

public sealed class InvalidPasswordException : CustomException
{
    public InvalidPasswordException() : base($"Password is invalid.")
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
    }
}
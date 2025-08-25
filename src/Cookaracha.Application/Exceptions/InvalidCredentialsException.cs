using Cookaracha.Core.Exceptions;
using System.Net;

namespace Cookaracha.Application.Exceptions;

internal sealed class InvalidCredentialsException : CustomException
{
    public InvalidCredentialsException() : base($"Invalid credentials.")
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
    }
}
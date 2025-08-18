using System.Net;

namespace Cookaracha.Core.Exceptions;

public sealed class InvalidEmailException : CustomException
{
    public string Email { get; }

    public InvalidEmailException(string email) : base($"Email: '{email}' is invalid.")
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
        Email = email;
    }
}
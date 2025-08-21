using Cookaracha.Core.Exceptions;
using System.Net;

namespace Cookaracha.Application.Exceptions;

internal sealed class UserNameAlreadyInUseException : CustomException
{
    public string UserName { get; }

    public UserNameAlreadyInUseException(string userName) : base($"User name: '{userName}' is already in use.")
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
        UserName = userName;
    }
}
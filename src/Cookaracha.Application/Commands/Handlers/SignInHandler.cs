using Cookaracha.Application.Abstractions;
using Cookaracha.Application.Exceptions;
using Cookaracha.Application.Security;
using Cookaracha.Core.Repositories;
using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Application.Commands.Handlers;

internal sealed class SignInHandler : ICommandHandler<SignIn>
{
    private readonly IUsersRepository _userRepository;
    private readonly IPasswordManager _passwordManager;
    private readonly ITokenStorage _tokenStorage;
    private readonly IAuthenticator _authenticator;

    public SignInHandler(
        IUsersRepository userRepository,
        IPasswordManager passwordManager,
        ITokenStorage tokenStorage,
        IAuthenticator authenticator)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
        _tokenStorage = tokenStorage;
        _authenticator = authenticator;
    }

    public async Task HandleAsync(SignIn command)
    {
        var user = await _userRepository.GetAsync(new Email(command.Email))
            ?? throw new InvalidCredentialsException();
        
        if (!_passwordManager.ValidatePassword(command.Password, user.Password))
            throw new InvalidCredentialsException();

        _tokenStorage.Set(_authenticator.CreateToken(user.Id));
    }
}
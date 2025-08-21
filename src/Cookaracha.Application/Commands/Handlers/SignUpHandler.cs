using Cookaracha.Application.Abstractions;
using Cookaracha.Application.Exceptions;
using Cookaracha.Application.Security;
using Cookaracha.Core.Abstractions;
using Cookaracha.Core.Repositories;
using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Application.Commands.Handlers;

internal sealed class SignUpHandler : ICommandHandler<SignUp>
{
    private readonly ITimeProvider _timeProvider;
    private readonly IUsersRepository _usersRepository;
    private readonly IPasswordManager _passwordManager;

    public SignUpHandler(
        ITimeProvider timeProvider,
        IUsersRepository usersRepository,
        IPasswordManager passwordManager)
    {
        _timeProvider = timeProvider;
        _usersRepository = usersRepository;
        _passwordManager = passwordManager;
    }

    public async Task HandleAsync(SignUp command)
    {
        var email = new Email(command.Email);
        var name = new UserName(command.Name);

        if (await _usersRepository.GetAsync(email) is not null)
            throw new EmailAlreadyInUseException(email);

        if (await _usersRepository.GetAsync(name) is not null)
            throw new UserNameAlreadyInUseException(name);

        await _usersRepository.AddAsync(new(
            command.Id,
            _timeProvider.UtcNow,
            name,
            email,
            _passwordManager.HashPassword(command.Password)));
    }
}
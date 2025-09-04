using Cookaracha.Application.Abstractions;
using Cookaracha.Application.Exceptions;
using Cookaracha.Application.Security;
using Cookaracha.Core.Abstractions;
using Cookaracha.Core.Exceptions;
using Cookaracha.Core.Repositories;
using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Application.Commands.Handlers;

internal sealed class UpdateUserHandler : ICommandHandler<UpdateUser>
{
    private readonly ITimeProvider _timeProvider;
    private readonly IUsersRepository _usersRepository;
    private readonly IPasswordManager _passwordManager;

    public UpdateUserHandler(
        ITimeProvider timeProvider,
        IUsersRepository usersRepository,
        IPasswordManager passwordManager)
    {
        _timeProvider = timeProvider;
        _usersRepository = usersRepository;
        _passwordManager = passwordManager;
    }

    public async Task HandleAsync(UpdateUser command)
    {
        var user = await _usersRepository.GetAsync(command.Id)
            ?? throw new UserNotFoundException(command.Id);

        if (!string.IsNullOrWhiteSpace(command.Name))
        {
            if (await _usersRepository.GetAsync(new UserName(command.Name)) is not null)
                throw new UserNameAlreadyInUseException(command.Name);

            user.ChangeName(command.Name);
        }

        if (!string.IsNullOrWhiteSpace(command.Email))
        {
            if (await _usersRepository.GetAsync(new Email(command.Email)) is not null)
                throw new EmailAlreadyInUseException(command.Email);

            user.ChangeEmail(command.Email);
        }

        if (!string.IsNullOrWhiteSpace(command.Password))
            user.ChangePassword(_passwordManager.HashPassword(command.Password));

        user.ChangeModifiedAt(_timeProvider.UtcNow);

        await _usersRepository.UpdateAsync(user);
    }
}
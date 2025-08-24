using Cookaracha.Application.Abstractions;
using Cookaracha.Core.Abstractions;
using Cookaracha.Core.Exceptions;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Commands.Handlers;

internal sealed class UpdateUserHandler : ICommandHandler<UpdateUser>
{
    private readonly ITimeProvider _timeProvider;
    private readonly IUsersRepository _usersRepository;

    public UpdateUserHandler(ITimeProvider timeProvider, IUsersRepository usersRepository)
    {
        _timeProvider = timeProvider;
        _usersRepository = usersRepository;
    }

    public async Task HandleAsync(UpdateUser command)
    {
        var user = await _usersRepository.GetAsync(command.Id)
            ?? throw new UserNotFoundException(command.Id);
        
        // TODO: Update user properties
        
        user.ChangeModifiedAt(_timeProvider.UtcNow);

        await _usersRepository.UpdateAsync(user);
    }
}
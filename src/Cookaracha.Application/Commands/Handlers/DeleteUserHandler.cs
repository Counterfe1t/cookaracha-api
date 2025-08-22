using Cookaracha.Application.Abstractions;
using Cookaracha.Core.Exceptions;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Commands.Handlers;

public sealed class DeleteUserHandler : ICommandHandler<DeleteUser>
{
    private readonly IUsersRepository _usersRepository;

    public DeleteUserHandler(IUsersRepository usersRepository)
        => _usersRepository = usersRepository;

    public async Task HandleAsync(DeleteUser command)
    {
        var user = await _usersRepository.GetAsync(command.Id)
            ?? throw new UserNotFoundException(command.Id);
        
        await _usersRepository.DeleteAsync(user);
    }
}
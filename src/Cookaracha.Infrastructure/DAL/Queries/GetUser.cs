using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;

namespace Cookaracha.Infrastructure.DAL.Queries;

public sealed record GetUser(Guid Id) : IQuery<UserDto>;
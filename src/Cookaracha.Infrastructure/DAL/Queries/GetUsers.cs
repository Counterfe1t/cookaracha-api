using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;

namespace Cookaracha.Infrastructure.DAL.Queries;

public sealed record GetUsers(int PageNumber, int PageSize) : IQuery<IEnumerable<UserDto>>;
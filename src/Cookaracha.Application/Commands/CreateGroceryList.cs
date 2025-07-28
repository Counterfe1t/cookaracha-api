using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;

namespace Cookaracha.Application.Commands;

public sealed record CreateGroceryList(Guid Id, string Name, IEnumerable<ItemDto> Items) : ICommand;
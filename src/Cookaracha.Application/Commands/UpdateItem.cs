using Cookaracha.Application.Abstractions;

namespace Cookaracha.Application.Commands;

public sealed record UpdateItem(
    Guid Id,
    Guid? ProductId,
    string Name,
    int Quantity,
    bool IsChecked) : ICommand;
using Cookaracha.Application.Abstractions;

namespace Cookaracha.Application.Commands;

public sealed record CreateItem(
    Guid Id,
    Guid GroceryListId,
    Guid? ProductId,
    string Name,
    int Quantity,
    bool IsChecked) : ICommand;
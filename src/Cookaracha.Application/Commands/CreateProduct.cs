﻿using Cookaracha.Application.Abstractions;

namespace Cookaracha.Application.Commands;

public sealed record CreateProduct(Guid Id, string Name) : ICommand;
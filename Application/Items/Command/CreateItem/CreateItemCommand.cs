using System;
using Application.Abstractions.Messaging;

namespace Application.Items.Command.CreateItem;

public sealed record CreateItemCommand(string Name, string Description, string Category, string URL) : ICommand<Guid>;
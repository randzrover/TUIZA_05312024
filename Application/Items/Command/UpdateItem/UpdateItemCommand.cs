using Application.Abstractions.Messaging;
using Domain.Entities;
using System;

namespace Application.Items.Command.UpdateItem;
public sealed record UpdateItemCommand(Guid Id,string Name, string Description, string Category, string Url) : ICommand<Item>;

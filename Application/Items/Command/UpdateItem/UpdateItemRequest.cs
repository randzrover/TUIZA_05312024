using Domain.Entities;
using System;

namespace Application.Items.Command.UpdateItem;

public sealed record UpdateItemRequest(Guid Id,string Name, string Description, string Category, string Url);

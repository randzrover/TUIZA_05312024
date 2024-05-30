using System;
using Application.Abstractions.Messaging;
using Application.Items.Queries.GetItemById;

namespace Application.Items.Queries.GetItemById;

public sealed record GetItemByIdQuery(Guid ItemId) : IQuery<ItemResponse>;
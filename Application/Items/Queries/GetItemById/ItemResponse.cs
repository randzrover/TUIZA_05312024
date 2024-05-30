using System;

namespace Application.Items.Queries.GetItemById;

public sealed record ItemResponse(Guid Id, string Name, string Description, string Category, string Url);
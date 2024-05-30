using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Items.Queries.GetItems;
public sealed record ItemsResponse(Guid id, string Name, string Description, string Category, string Url);
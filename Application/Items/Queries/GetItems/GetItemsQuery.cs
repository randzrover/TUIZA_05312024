using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Queries.GetItems;
public sealed record GetItemsQuery() : IQuery<IEnumerable<ItemsResponse>>;

using Application.Abstractions.Messaging;
using Application.Items.Queries.GetItemById;
using Dapper;
using Domain.Abstractions;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Items.Queries.GetItems;
internal sealed class GetItemsQueryHandler : IQueryHandler<GetItemsQuery, IEnumerable<ItemsResponse>>
{
    private readonly IDbConnection _dbConnection;

    public GetItemsQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;

    public async Task<IEnumerable<ItemsResponse>> Handle(
        GetItemsQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = @"SELECT * FROM ""Items"" ";

        var items = await _dbConnection.QueryAsync<ItemsResponse>(
            sql,
            null);

        if (items is null)
        {
            throw new ItemsEmptyExecption();
        }

        return items;

    }
}

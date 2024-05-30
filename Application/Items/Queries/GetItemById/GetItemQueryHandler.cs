using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Application.Items.Queries.GetItemById;
using Dapper;
using Domain.Exceptions;

namespace Application.Webinars.Queries.GetWebinarById;

internal sealed class GetItemQueryHandler : IQueryHandler<GetItemByIdQuery, ItemResponse>
{
    private readonly IDbConnection _dbConnection;

    public GetItemQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;

    public async Task<ItemResponse> Handle(
        GetItemByIdQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = @"SELECT * FROM ""Items"" WHERE ""Id"" = @ItemId";

        var item = await _dbConnection.QueryFirstOrDefaultAsync<ItemResponse>(
            sql,
            new { request.ItemId });

        if (item is null)
        {
            throw new ItemNotFoundException(request.ItemId);
        }

        return item;
    }
}
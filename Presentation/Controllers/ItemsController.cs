using Application.Items.Command.CreateItem;
using Application.Items.Command.UpdateItem;
using Application.Items.Queries.GetItemById;
using Application.Items.Queries.GetItems;
using Application.Webinars.Commands.CreateWebinar;
using Application.Webinars.Queries.GetWebinarById;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Controllers;

public sealed class ItemsController : ApiController
{
    [HttpGet("{Id:guid}")]
    [ProducesResponseType(typeof(ItemResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetItem(Guid Id, CancellationToken cancellationToken)
    {
        var query = new GetItemByIdQuery(Id);

        var webinar = await Sender.Send(query, cancellationToken);

        return Ok(webinar);
    }

    [HttpGet()]
    [ProducesResponseType(typeof(ItemResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetItems(CancellationToken cancellationToken)
    {
        var query = new GetItemsQuery();

        var items = await Sender.Send(query, cancellationToken);

        return Ok(items);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateItem(
        [FromBody] CreateItemRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateItemCommand>();

        var itemId = await Sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetItem), new { itemId }, itemId);
    }

    [HttpPatch]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateItem(
        [FromBody] UpdateItemCommand request,
        CancellationToken cancellationToken)
    {
        var command = request.Adapt<UpdateItemCommand>();

        var item = await Sender.Send(command, cancellationToken);

        return Ok(item);
    }
}
using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Items.Command.UpdateItem;
public sealed class UpdateItemCommandHandler : ICommandHandler<UpdateItemCommand, Item>
{
    private readonly IItemRepository _itemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateItemCommandHandler(IItemRepository itemRepository, IUnitOfWork unitOfWork)
    {
        _itemRepository = itemRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Item> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var item = new Item(request.Id, request.Name, request.Description, request.Category, request.Url);

        _itemRepository.Update(item);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return item;
    }
}

using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Items.Command.CreateItem;

internal sealed class CreateItemCommandHandler : ICommandHandler<CreateItemCommand, Guid>
{
    private readonly IItemRepository _itemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateItemCommandHandler(IItemRepository itemRepository, IUnitOfWork unitOfWork)
    {
        _itemRepository = itemRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<Guid> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var item = new Item(Guid.NewGuid(),request.Name, request.Description, request.Category,request.URL);

        _itemRepository.Insert(item);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return item.Id;
    }
}
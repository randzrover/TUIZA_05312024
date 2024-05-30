using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Abstractions;

public interface IItemRepository
{
    IEnumerable<Item> GetItems();
    void Insert(Item item);
    void Update(Item item);
}
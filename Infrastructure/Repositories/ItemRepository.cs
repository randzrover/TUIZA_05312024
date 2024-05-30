using Domain.Abstractions;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories;

public sealed class ItemRepository : IItemRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ItemRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public IEnumerable<Item> GetItems() => _dbContext.Set<Item>().ToList();

    public void Insert(Item item) => _dbContext.Set<Item>().Add(item);

    public void Update(Item item) => _dbContext.Set<Item>().Update(item);

}
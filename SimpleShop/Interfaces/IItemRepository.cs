using SimpleShop.Context.Models;

namespace SimpleShop.Interfaces;

public interface IItemRepository
{
    Task Add(List<Item> items);
    Task Remove(Guid id);
    Task<IEnumerable<Item>> GetByClientDni(string dni);
    Task<Item> Update(Item item);
}
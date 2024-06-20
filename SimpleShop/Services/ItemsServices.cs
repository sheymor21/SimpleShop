using SimpleShop.DTO;
using SimpleShop.Interfaces;

namespace SimpleShop.Services;

public class ItemsServices : IItemsServices
{
    public void AddItemsAsync(List<ItemAddRequest> itemAddRequests)
    {
        throw new NotImplementedException();
    }

    public ItemGetRequest UpdateItem(Guid id, ItemUpdateRequest itemUpdateRequest)
    {
        throw new NotImplementedException();
    }
}
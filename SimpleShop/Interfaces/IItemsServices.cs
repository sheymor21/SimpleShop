using SimpleShop.DTO;

namespace SimpleShop.Interfaces;

public interface IItemsServices
{
    void AddItemsAsync(List<ItemAddRequest> itemAddRequests);
    ItemGetRequest UpdateItem(Guid id, ItemUpdateRequest itemUpdateRequest);
}
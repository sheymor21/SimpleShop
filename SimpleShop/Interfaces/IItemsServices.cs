using SimpleShop.DTO;

namespace SimpleShop.Interfaces;

public interface IItemsServices
{
    Task AddItemsAsync(List<ItemAddRequest> itemAddRequests);
    Task RemoveItemAsync(Guid id);
    Task<ItemGetRequest> UpdateItem(Guid id, ItemUpdateRequest itemUpdateRequest);
}
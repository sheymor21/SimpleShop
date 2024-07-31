using SimpleShop.DTO;

namespace SimpleShop.Interfaces;

public interface IItemsServices
{
    Task AddItemsAsync(List<ItemDto.AddRequest> itemAddRequests);
    Task RemoveItemAsync(Guid id);
    Task<ItemDto.GetRequest> UpdateItem(Guid id, ItemDto.UpdateRequest itemUpdateRequest);
}
using SimpleShop.Context.Models;
using SimpleShop.DTO;
using SimpleShop.Interfaces;

namespace SimpleShop.Services;

public class ItemsServices : IItemsServices
{
    private readonly IItemRepository _itemRepository;
    private readonly IClientRepository _clientRepository;

    public ItemsServices(IItemRepository itemRepository, IClientRepository clientRepository)
    {
        _itemRepository = itemRepository;
        _clientRepository = clientRepository;
    }

    public async Task AddItemsAsync(List<ItemAddRequest> itemAddRequests)
    {
        List<Item> items = new();
        foreach (var itemDto in itemAddRequests)
        {
            string clientId = await _clientRepository.GetClientIdByDni(itemDto.ClientDni);
            Item item = new()
            {
                Name = itemDto.Name,
                Price = itemDto.Price,
                Brand = itemDto.Brand,
                CreateAt = DateTime.Now,
                ClientId = clientId
            };
            item.UpdateAt = item.CreateAt;
            items.Add(item);
        }

        await _itemRepository.Add(items);
    }

    public async Task RemoveItemAsync(Guid id)
    {
        await _itemRepository.Remove(id);
    }

    public async Task<ItemGetRequest> UpdateItem(Guid id, ItemUpdateRequest itemUpdateRequest)
    {
        Item newItem = new()
        {
            ItemId = id.ToString(),
            Name = itemUpdateRequest.Name,
            Price = itemUpdateRequest.Price,
            Brand = itemUpdateRequest.Brand,
            UpdateAt = DateTime.Now,
        };
        var item = await _itemRepository.Update(newItem);
        ItemGetRequest itemGetRequest = new()
        {
            Id = Guid.Parse(item.ItemId),
            Name = item.Name,
            Price = item.Price,
            Brand = item.Brand,
        };
        return itemGetRequest;
    }
}
using SimpleShop.Interfaces;

namespace SimpleShop.Validations;

public class ItemValidation : IItemValidations
{
    private readonly IItemRepository _itemRepository;

    public ItemValidation(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<bool> AnyById(Guid id)
    {
        var result = await _itemRepository.AnyById(id);
        return result;
    }
}
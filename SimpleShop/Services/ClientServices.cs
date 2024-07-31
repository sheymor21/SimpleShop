using SimpleShop.Context.Models;
using SimpleShop.DTO;
using SimpleShop.Interfaces;

namespace SimpleShop.Services;

public class ClientServices : IClientServices
{
    private readonly IItemRepository _itemRepository;
    private readonly IClientRepository _clientRepository;

    public ClientServices(IItemRepository itemRepository, IClientRepository clientRepository)
    {
        _itemRepository = itemRepository;
        _clientRepository = clientRepository;
    }

    public async Task AddClientAsync(ClientDto.AddRequest clientAddRequestRequest)
    {
        Client client = new()
        {
            Dni = clientAddRequestRequest.Dni,
            FirstName = clientAddRequestRequest.Dni,
            LastName = clientAddRequestRequest.LastName,
            Age = clientAddRequestRequest.Age
        };
        await _clientRepository.Add(client);
    }

    public async Task<ClientDto.GetRequest> GetClientAsync(string dni)
    {
        List<ItemDto.GetRequest> itemsDto = new();
        var client = await _clientRepository.GetByDni(dni);

        var items = await _itemRepository.GetByClientDni(dni);
        foreach (var item in items)
        {
            ItemDto.GetRequest itemDto = new(Guid.Parse(item.ItemId), item.Name, item.Price, item.Brand);
            itemsDto.Add(itemDto);
        }

        ClientDto.GetRequest clientDto = new(client.Dni, client.FirstName, client.LastName, client.Age, itemsDto);
        return clientDto;
    }

    public async Task<ClientDto.GetRequestWithoutItem> UpdateClientAsync(
        ClientDto.UpdateRequest clientUpdateRequestRequest,
        string dni)
    {
        Client oldClient = new()
        {
            Dni = dni,
            FirstName = clientUpdateRequestRequest.FirstName,
            LastName = clientUpdateRequestRequest.LastName,
            Age = clientUpdateRequestRequest.Age
        };
        var client = await _clientRepository.Update(oldClient);

        ClientDto.GetRequestWithoutItem dto = new(
            dni,
            clientUpdateRequestRequest.FirstName,
            clientUpdateRequestRequest.LastName,
            clientUpdateRequestRequest.Age
        );
        return dto;
    }
}
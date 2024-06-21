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

    public async Task AddClientAsync(ClientAddRequest clientAddRequest)
    {
        Client client = new()
        {
            ClientId = Guid.NewGuid().ToString(),
            Dni = clientAddRequest.Dni,
            FirstName = clientAddRequest.Dni,
            LastName = clientAddRequest.LastName,
            Age = clientAddRequest.Age
        };
        await _clientRepository.Add(client);
    }

    public async Task<ClientGetRequest> GetClientAsync(string dni)
    {
        var client = await _clientRepository.GetByDni(dni);
        ClientGetRequest clientDto = new()
        {
            Dni = client.Dni,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Age = client.Age
        };
        var items = await _itemRepository.GetByClientDni(dni);
        foreach (var item in items)
        {
            ItemGetRequest itemDto = new()
            {
                Id = Guid.Parse(item.ItemId),
                Name = item.Name,
                Price = item.Price,
                Brand = item.Brand
            };
            clientDto.Items.Add(itemDto);
        }

        return clientDto;
    }

    public async Task<ClientGetRequest> UpdateClientAsync(ClientUpdateRequest clientUpdateRequest)
    {
        Client oldClient = new()
        {
            Dni = clientUpdateRequest.Dni,
            FirstName = clientUpdateRequest.FirstName,
            LastName = clientUpdateRequest.LastName,
            Age = clientUpdateRequest.Age
        };
        var client = await _clientRepository.Update(oldClient);
        ClientGetRequest dto = new()
        {
            Dni = client.Dni,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Age = client.Age,
        };
        return dto;
    }
}
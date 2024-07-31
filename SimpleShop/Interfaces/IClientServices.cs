using SimpleShop.DTO;

namespace SimpleShop.Interfaces;

public interface IClientServices
{
    Task AddClientAsync(ClientDto.AddRequest clientAddRequest);
    Task<ClientDto.GetRequest> GetClientAsync(string dni);
    Task<ClientDto.GetRequestWithoutItem> UpdateClientAsync(ClientDto.UpdateRequest clientUpdateRequest, string dni);
}
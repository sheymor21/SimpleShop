using SimpleShop.DTO;

namespace SimpleShop.Interfaces;

public interface IClientServices
{
    Task AddClientAsync(ClientAddRequest clientAddRequest);
    Task<ClientGetRequest> GetClientAsync(string dni);
    Task<ClientGetRequest> UpdateClientAsync(ClientUpdateRequest clientUpdateRequest);
}
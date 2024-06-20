using SimpleShop.DTO;

namespace SimpleShop.Interfaces;

public interface IClientServices
{
    void AddClientAsync(ClientAddRequest clientAddRequest);
    ClientGetRequest GetClientAsync(string dni);
    ClientGetRequest UpdateClientAsync(ClientUpdateRequest clientUpdateRequest);
}
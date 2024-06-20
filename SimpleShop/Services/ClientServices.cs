using SimpleShop.DTO;
using SimpleShop.Interfaces;

namespace SimpleShop.Services;

public class ClientServices : IClientServices
{
    public void AddClientAsync(ClientAddRequest clientAddRequest)
    {
        throw new NotImplementedException();
    }

    public ClientGetRequest GetClientAsync(string dni)
    {
        throw new NotImplementedException();
    }

    public ClientGetRequest UpdateClientAsync(ClientUpdateRequest clientUpdateRequest)
    {
        throw new NotImplementedException();
    }
}
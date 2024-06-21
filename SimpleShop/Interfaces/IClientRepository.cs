using SimpleShop.Context.Models;
using SimpleShop.DTO;

namespace SimpleShop.Interfaces;

public interface IClientRepository
{
    Task Add(Client client);
    Task<Client> Update(Client client);
    Task<Client> GetByDni(string dni);
    Task<string> GetClientIdByDni(string dni);
}
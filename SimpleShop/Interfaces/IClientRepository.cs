using SimpleShop.Context.Models;
using SimpleShop.DTO;

namespace SimpleShop.Interfaces;

public interface IClientRepository
{
    Task Add(Client client);
    Task<Client> Find(Guid id);
    Task<Client> Update(Client client);
    Task Remove(string dni);
    Task<Client> GetByDni(string dni);
    Task<bool> AnyByDni(string dni);
    Task<bool> AnyById(Guid id);
    Task<string> GetIdByDni(string dni);
}
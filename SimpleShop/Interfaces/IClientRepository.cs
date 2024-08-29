using SimpleShop.Context.Models;
using SimpleShop.DTO;

namespace SimpleShop.Interfaces;

public interface IClientRepository
{
    Task AddAsync(Client client);
    Task<Client> FindAsync(string id);
    Task<Client> UpdateAsync(Client client);
    Task RemoveAsync(string dni);
    Task<Client> GetByDniAsync(string dni);
    Task<bool> AnyByDniAsync(string dni);
    Task<bool> AnyByIdAsync(string id);
    Task<string> GetIdByDniAsync(string dni);
}
namespace SimpleShop.Interfaces;

public interface IClientValidation
{
    Task<bool> AnyClientByDni(string dni);
    Task<bool> AnyClientById(Guid id);
}
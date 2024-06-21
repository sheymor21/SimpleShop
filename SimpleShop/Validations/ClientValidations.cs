using SimpleShop.Interfaces;

namespace SimpleShop.Validations;

public class ClientValidations : IClientValidation
{
    private readonly IClientRepository _clientRepository;

    public ClientValidations(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<bool> AnyClientByDni(string dni)
    {
        var result = await _clientRepository.AnyByDni(dni);
        return result;
    }
    
    public async Task<bool> AnyClientById(Guid id)
    {
        var result = await _clientRepository.AnyById(id);
        return result;
    }
}
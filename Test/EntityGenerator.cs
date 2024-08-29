using SimpleShop.Context;

namespace Test;

public class EntityGenerator
{
    private readonly IFixture _fixture;
    private readonly DatabaseContext _context;

    public EntityGenerator(IFixture fixture, DatabaseContext context)
    {
        _fixture = fixture;
        _context = context;
    }

    public async Task<Client> GenerateClientAsync()
    {
        Client client = _fixture.Build<Client>().Without(w => w.ClientId).Create();
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
        return client;
    }
}
using Microsoft.EntityFrameworkCore;

namespace Test.UnitTest;

[Collection("Database collection")]
public class ClientTest
{
    private readonly ClientRepository _clientRepository;
    private readonly IFixture _fixture;
    private readonly DatabaseContextFixture _contextFixture;
    private readonly EntityGenerator _generator;

    public ClientTest()
    {
        _contextFixture = new();
        _clientRepository = new ClientRepository();
        _fixture = new Fixture();
        _generator = new(_fixture, _contextFixture.Context);
    }

    [Fact]
    public async Task ClientAddTest()
    {
        Client client = _fixture.Build<Client>().Without(w => w.ClientId).Create();
        await _clientRepository.AddAsync(client);
        var result = await _contextFixture.Context.Clients.FindAsync(client.ClientId);
        result.Should().BeEquivalentTo(client);
    }

    [Fact]
    public async Task ClientGetTest()
    {
        var client = await _generator.GenerateClientAsync();
        var result = await _clientRepository.FindAsync(client.ClientId);
        result.Should().BeEquivalentTo(client);
    }

    [Fact]
    public async Task ClientUpdateTest()
    {
        var client = await _generator.GenerateClientAsync();

        client = _fixture.Build<Client>()
            .With(w => w.ClientId, client.ClientId)
            .With(w => w.Dni, client.Dni)
            .Create();
        var result = await _clientRepository.UpdateAsync(client);
        result.Should().BeEquivalentTo(client);
    }

    [Fact]
    public async Task ClientDeleteTest()
    {
        var client = await _generator.GenerateClientAsync();

        await _clientRepository.RemoveAsync(client.Dni);
        var result = await _contextFixture.Context.Clients.FirstOrDefaultAsync(w => w.ClientId == client.ClientId);
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetClientByDniTest()
    {
        var client = await _generator.GenerateClientAsync();

        var result = await _clientRepository.GetByDniAsync(client.Dni);
        result.Should().BeEquivalentTo(client);
    }

    [Fact]
    public async Task GetClientIdByDniTest()
    {
        var client = await _generator.GenerateClientAsync();

        var result = await _clientRepository.GetIdByDniAsync(client.Dni);
        result.Should().BeEquivalentTo(client.ClientId);
    }
}
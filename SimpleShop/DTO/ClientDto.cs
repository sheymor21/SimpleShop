namespace SimpleShop.DTO;

public class ClientAddRequest : AClientDto
{
}

public class ClientGetRequest : AClientDto
{
    public List<ItemGetRequest> Items { get; } = new();
}

public class ClientUpdateRequest : AClientDto
{
}
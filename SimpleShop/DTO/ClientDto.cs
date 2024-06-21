namespace SimpleShop.DTO;

public class ClientAddRequest : AClientDto
{
}

public class ClientGetRequest : AClientDto
{
    public List<ItemGetRequest> Items { get; } = new();
}

public class ClientUpdateRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}
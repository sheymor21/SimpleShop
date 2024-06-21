namespace SimpleShop.DTO;

public class ItemAddRequest : AItemDto
{
    public string ClientDni { get; set; }
}

public class ItemGetRequest : AItemDto
{
    public Guid Id { get; set; }
}

public class ItemUpdateRequest : AItemDto
{
}
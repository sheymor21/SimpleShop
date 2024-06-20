namespace SimpleShop.DTO;

public class ItemAddRequest : AItemDto
{
    public Guid ClientId { get; set; }
}

public class ItemGetRequest : AItemDto
{
    public Guid Id { get; set; }
}

public class ItemUpdateRequest : AItemDto
{
}
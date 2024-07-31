namespace SimpleShop.DTO;

public class ItemDto
{
    public record AddRequest(
        string ClientDni,
        string Name,
        double Price,
        string Brand
    );

    public record UpdateRequest(
        string Name,
        double Price,
        string Brand
    );

    public record GetRequest(
        Guid Id,
        string Name,
        double Price,
        string Brand
    );
}
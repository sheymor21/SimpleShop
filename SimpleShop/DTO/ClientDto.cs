namespace SimpleShop.DTO;

public class ClientDto()
{
    public record AddRequest(
        string Dni,
        string FirstName,
        string LastName,
        int Age
    );

    public record UpdateRequest(
        string FirstName,
        string LastName,
        int Age
    );

    public record GetRequest(
        string Dni,
        string FirstName,
        string LastName,
        int Age,
        List<ItemDto.GetRequest> Items
    );

    public record GetRequestWithoutItem(
        string Dni,
        string FirstName,
        string LastName,
        int Age
    );

}
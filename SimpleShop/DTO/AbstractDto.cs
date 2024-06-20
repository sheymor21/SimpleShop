namespace SimpleShop.DTO;

public abstract class AClientDto
{
    public string Dni { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

public abstract class AItemDto
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Brand { get; set; }
}
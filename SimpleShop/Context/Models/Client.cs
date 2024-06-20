namespace SimpleShop.Context.Models;

public class Client
{
    public Guid ClientId { get; set; }
    public string Dni { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    
    protected string FullName => $"{FirstName} {LastName}";
    
    public List<Item> Items { get; } = new();
}
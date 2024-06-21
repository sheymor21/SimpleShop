namespace SimpleShop.Context.Models;

public class Client
{
    public string ClientId { get; set; }
    public string Dni { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    
    public string FullName => $"{FirstName} {LastName}";
    
    public List<Item> Items { get; } = new();
}
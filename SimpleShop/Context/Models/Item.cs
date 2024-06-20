namespace SimpleShop.Context.Models;

public class Item
{
    public Guid ItemId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Brand { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }

    public Guid ClientId { get; set; }
    public Client Client { get; } = new();
}
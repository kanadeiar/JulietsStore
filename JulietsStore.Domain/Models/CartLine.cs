namespace JulietsStore.Domain.Models;

public class CartLine
{
    public int Id { get; set; }
    public Product Product { get; set; } = new();
    public int Quantity { get; set; }
}
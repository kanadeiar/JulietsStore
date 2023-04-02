namespace JulietsStore.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Decription { get; set; } = string.Empty;
    [Column(TypeName="decimal(8, 2)")]
    public decimal Price { get; set; }
}
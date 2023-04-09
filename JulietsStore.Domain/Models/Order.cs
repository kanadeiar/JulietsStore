namespace JulietsStore.Domain.Models;

public class Order
{
    public int Id { get; set; }
    public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? Line3 { get; set; }
    [Required]
    public string? City { get; set; }
    [Required]
    public string? State { get; set; }
    [Required]
    public string? Country { get; set; }
    public string? Zip { get; set; }
    public bool GiftWrap { get; set; }
    public bool IsShipped { get; set; }
}
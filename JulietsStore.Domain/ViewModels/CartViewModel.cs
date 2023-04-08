namespace JulietsStore.Domain.Models;

public class CartViewModel
{
    public ICart? Cart { get; set; }
    public string? ReturnUrl { get; set; }
}
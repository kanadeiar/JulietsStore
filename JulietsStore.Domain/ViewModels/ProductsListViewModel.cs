namespace JulietsStore.Domain.ViewModels;

public class ProductsListViewModel
{
    public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
    public PagingInfoViewModel? PagingInfo { get; set; }
    public string? CurrentCategory { get; set; }
}
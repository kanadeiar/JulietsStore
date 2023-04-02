namespace JulietsStore.Infra.Data;

public class ProductsRepo : IProductsRepo
{
    private readonly JulietsStoreDbContext _context;
    public ProductsRepo(JulietsStoreDbContext context)
    {
        _context = context;
    }
    public IQueryable<Product> Products => _context.Products;
}
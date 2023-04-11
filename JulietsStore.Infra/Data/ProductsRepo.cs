namespace JulietsStore.Infra.Data;

public class ProductsRepo : IProductsRepo
{
    private readonly DbContext _context;
    public ProductsRepo(JulietsStoreDbContext context)
    {
        _context = context;
    }
    public IQueryable<Product> Products => _context.Set<Product>();
    public void CreateProduct(Product product)
    {
        _context.Add(product);
        _context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        _context.SaveChanges();
    }

    public void DeleteProduct(Product product)
    {
        _context.Remove(product);
        _context.SaveChanges();
    }
}
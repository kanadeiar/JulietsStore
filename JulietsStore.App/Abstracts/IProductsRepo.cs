namespace JulietsStore.App.Abstracts;

public interface IProductsRepo
{
    IQueryable<Product> Products { get; }
    void CreateProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
}
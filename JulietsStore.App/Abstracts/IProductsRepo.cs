namespace JulietsStore.App.Abstracts;

public interface IProductsRepo
{
    IQueryable<Product> Products { get; }
}
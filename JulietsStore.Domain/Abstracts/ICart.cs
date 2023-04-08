namespace JulietsStore.Domain.Abstracts;

public interface ICart
{
    public IList<CartLine> Lines { get; set; }
    public void AddItem(Product product, int quantity);
    public void RemoveLine(Product product);
    public decimal TotalSum();
    public void Clear();
}
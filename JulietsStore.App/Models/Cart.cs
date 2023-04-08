namespace JulietsStore.App.Models;

public class Cart : ICart
{
    public IList<CartLine> Lines { get; set; } = new List<CartLine>();
    
    public virtual void AddItem(Product product, int quantity)
    {
        var line = Lines.Where(x => x.Product?.Id == product.Id).FirstOrDefault();
        if (line is { })
        {
            line.Quantity++;
        }
        else
        {
            Lines.Add( new CartLine{ Product = product, Quantity = quantity } );
        }
    }
    public virtual void RemoveLine(Product product)
    {
        if (Lines.Where(x => x.Product?.Id == product.Id).FirstOrDefault() is CartLine line)
        {
            Lines.Remove(line);
        }
    }
    public virtual decimal TotalSum()
    {
        return Lines.Sum(x => x.Product!.Price * x.Quantity);
    } 
    public virtual void Clear() 
    { 
        Lines.Clear();
    }
}
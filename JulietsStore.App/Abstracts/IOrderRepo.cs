namespace JulietsStore.App.Abstracts;

public interface IOrderRepo
{
    IQueryable<Order> Orders { get; }
    void SaveOrder(Order order);
}